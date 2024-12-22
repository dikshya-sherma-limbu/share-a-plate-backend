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

        public DbSet<IndividualDonation> IndividualDonations { get; set; }
        public DbSet<OrganizationDonation> OrganizationDonations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// ensures that the base class's OnModelCreating method is called first to have the base class's behavior
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IndividualDonation>()
            //    .HasOne(d => d.User)
            //    .WithMany(u => u.IndividualDonations)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);  // Deletes donations when user is deleted

            //modelBuilder.Entity<OrganizationDonation>()
            //    .HasOne(d => d.User)
            //    .WithMany(u => u.OrganizationDonations)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();  // Ensures unique email addresses
        }



    }
}
