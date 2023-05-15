using Microsoft.EntityFrameworkCore;
using System;
using Taxi.DatabaseAccess.Entities;

namespace Taxi.DatabaseAccess
{
    public class TaxiContext : DbContext
    {
        protected TaxiContext()
        {
        }

        public TaxiContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog = Taxi; Integrated Security = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Entity).Assembly);
            modelBuilder.Entity<InDebted>().HasKey(x => new { x.RideId, x.DebtorId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Maintenace> Maintenaces { get; set; }
        public DbSet<MaintenaceType> MaintenaceTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<DebtCollection> DebtCollections { get; set; }
        public DbSet<Debtor> Debtors { get; set;}
        public DbSet<InDebted> InDebteds { get; set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationPrice> LocationPrices { get; set; }
        public DbSet<Ride> Rides { get; set; }
    }
}
