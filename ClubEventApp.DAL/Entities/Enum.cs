namespace ClubEventApp.DAL.Entities
{
    public enum EventStatus
    {
        Draft = 0,       // Đang nháp
        Published = 1,   // Đã mở đăng ký
        Ongoing = 2,     // Đang diễn ra
        Completed = 3,   // Đã kết thúc
        Cancelled = 4    // Đã hủy
    }

    public enum ApplicationStatus
    {
        Pending = 0,     // Chờ duyệt
        Approved = 1,    // Đã duyệt
        Rejected = 2     // Bị từ chối
    }
}