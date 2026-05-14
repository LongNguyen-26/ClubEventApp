using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClubEventApp.DAL.Entities;

namespace ClubEventApp.DAL
{
    // Đổi từ internal sang public
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Thêm Constructor nhận DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Khai báo các bảng
        public DbSet<Event> Events { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Bắt buộc phải có để khởi tạo các bảng của Identity
            base.OnModelCreating(builder);

            // Cấu hình Fluent API để tránh lỗi Cascade Delete của SQL Server
            builder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasOne(e => e.Creator)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.CreatorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}