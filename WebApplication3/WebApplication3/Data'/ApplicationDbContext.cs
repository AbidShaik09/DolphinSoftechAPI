using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

namespace WebApplication3.Data_
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Report> reports { get; set; }

    }
}
