// ClubEventApp.DTO/CreateEventViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace ClubEventApp.DTO
{
    public class CreateEventViewModel
    {
        [Required(ErrorMessage = "Tên sự kiện không được để trống")]
        [StringLength(255)]
        [Display(Name = "Tên sự kiện")]
        public string EventName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thời gian bắt đầu")]
        [Display(Name = "Thời gian bắt đầu")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thời gian kết thúc")]
        [Display(Name = "Thời gian kết thúc")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa điểm")]
        [StringLength(200)]
        [Display(Name = "Địa điểm")]
        public string Location { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Số lượng phải lớn hơn 0")]
        [Display(Name = "Số lượng tối đa")]
        public int MaxCapacity { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập hạn chót đăng ký")]
        [Display(Name = "Hạn chót đăng ký")]
        public DateTime RegistrationDeadline { get; set; }
    }
}