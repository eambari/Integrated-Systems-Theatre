using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheatreApp.Web.Models;

namespace TheatreApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<TheatreUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
    }
}
