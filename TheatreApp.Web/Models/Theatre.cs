﻿using System.ComponentModel.DataAnnotations;

namespace TheatreApp.Web.Models
{
    public class Theatre
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime ShowDate { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Ticket>? TheatreTickets { get; set; }
    }
}
