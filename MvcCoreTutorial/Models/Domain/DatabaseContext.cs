using Microsoft.EntityFrameworkCore;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts):base(opts)
        {
                
        }

        public DbSet<Person> Person { get; set; } // it will create Person table in database
    }
}
