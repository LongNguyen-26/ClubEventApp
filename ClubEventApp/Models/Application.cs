using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubEventApp.Models
{
    public class Application
    {
        [Key]
        public string ApplicationID { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string EventID { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }
    }
}
