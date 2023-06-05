using Microsoft.EntityFrameworkCore;
using System;
using Taxi.DatabaseAccess.Configuration;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess
{
    public class TaxiDbContext : DbContext
    {

        public TaxiDbContext(DbContextOptions options = null) : base(options)
        {
            Database.EnsureCreated();
        }

        public TaxiDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog = Taxi; Integrated Security = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration<>).Assembly);
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId });
            modelBuilder.Entity<InDebted>().HasKey(x => new { x.RideId, x.DebtorId });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            break;
                        case EntityState.Modified:
                            e.EditedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            e.IsActive = false;
                            e.DeletedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<DebtCollection> DebtCollections { get; set; }
        public DbSet<Debtor> Debtors { get; set;}
        public DbSet<InDebted> InDebteds { get; set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationPrice> LocationPrices { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
    }
}
