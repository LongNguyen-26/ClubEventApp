using ClubEventApp.BLL.IServices;
using ClubEventApp.BLL.Services;
using ClubEventApp.DAL;
using ClubEventApp.DAL.Entities;
using ClubEventApp.DAL.IRepositories;
using ClubEventApp.DAL.Repositories;
using ClubEventApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Đăng ký ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Đăng ký Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// DAL
builder.Services.AddScoped<IEventRepository, EventRepository>();
// BLL
builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

// Tự động Migrate và Seed Roles/Users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // 1. Lấy DbContext và chạy Migrate tự động (Quan trọng: Sửa lỗi ExecuteDbDataReaderAsync)
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();

        // 2. Sau khi DB đã sẵn sàng, tiến hành Seed Data
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // Tạo role Admin nếu chưa có
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        // Tạo tài khoản Admin test nếu chưa có
        var adminEmail = "admin@club.com";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "Ban Điều Hành"
            };
            // Lưu ý: Đảm bảo mật khẩu đáp ứng đủ độ khó của Identity (chữ hoa, chữ thường, số, ký tự đặc biệt)
            await userManager.CreateAsync(admin, "Admin@123");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
    catch (Exception ex)
    {
        // Log lỗi ra console nếu có vấn đề về Database để dễ debug
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Đã xảy ra lỗi khi migrate hoặc seed dữ liệu vào database.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Thêm UseAuthentication TRƯỚC UseAuthorization để hệ thống nhận diện được User đăng nhập
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();