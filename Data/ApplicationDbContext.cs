using Microsoft.EntityFrameworkCore;
using share_a_plate_backend.Models;

namespace share_a_plate_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor for ApplicationDbContext class that
        // takes in DbContextOptions<ApplicationDbContext> option
        // and passes it to the base class constructor .
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

            // DBset for User model
            public DbSet<User> Users { get; set; }
    
    
    }
}
