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

        [Required]
        public string CreatorID { get; set; }

        [ForeignKey("CreatorID")]
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
