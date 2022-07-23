using BackendServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendServer.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<OsobaModel> Osobe { get; set; }

        public DbSet<StudentiModel> Studenti { get; set; } 

    }
}
