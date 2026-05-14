using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace ClubEventApp.DAL.Entities
{
    public class Event
    {
        // This means Event class has to be instruced first, so that the Application class can reference it.
        public Event()
        {
            Applications = new HashSet<Application>();
        }

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
        public EventStatus Status { get; set; }

        [Required]
        public string CreatorID { get; set; }

        [ForeignKey("CreatorID")]
        public virtual ApplicationUser Creator { get; set; }

        // It means that one event can have many applications, and each application is associated with one event. The Applications property in the Event class represents the collection of applications that are linked to that specific event.
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
