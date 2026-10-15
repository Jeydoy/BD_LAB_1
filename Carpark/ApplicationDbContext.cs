using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Carpark.Models;

namespace Carpark
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarRentalDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().ToView("vw_ActiveVehicles");

            modelBuilder.Entity<Vehicle>().Ignore(v => v.IsDeleted);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.UpdatedAt);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.UpdatedBy);
        }
    }
}