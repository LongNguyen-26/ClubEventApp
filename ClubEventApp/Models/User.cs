using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace ClubEventApp.Models
{
    public abstract class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        //public string FullName { get; set; }
        public string Email { get; set; }

        public abstract void Login();

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string StudentID { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; } = new List<Event>();

        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
