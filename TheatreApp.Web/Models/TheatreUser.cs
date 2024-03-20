using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace TheatreApp.Web.Models
{
    public class TheatreUser : IdentityUser
    {
        [Key]
        public Guid Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Ticket>? UserTickets { get; set; }
    }
}
