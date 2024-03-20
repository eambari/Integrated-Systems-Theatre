using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreApp.Web.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int NumberOfPeople {  get; set; }

        [Required]
        public Guid TheatreId { get; set; }

        [ForeignKey("TheatreId")]
        public virtual Theatre? TheatreShow { get; set; }

        public virtual TheatreUser? BoughtBy { get; set; }
    }
}
