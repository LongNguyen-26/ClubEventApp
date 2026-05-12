using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace ClubEventApp.Models
{
    public class Event
    {
        [Key]
        public string EventID { get; set; }

        [Required]
        [StringLength(255)]
        public string EventName { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        public int AvailableSlots { get; set; }

        [Required]
        public DateTime RegistrationDeadline { get; set; }

        [Required]
        public EventStatus Status { get; set; } // Có thể cân nhắc dùng Enum (vd: EventStatus) thay vì string

        [Required]
        public string CreatorID { get; set; }

        [ForeignKey("CreatorID")]
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
