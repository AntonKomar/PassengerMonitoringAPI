using PassengersMonitoring.Data.Extension;
using Microsoft.EntityFrameworkCore;
using PassengersMonitoring.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PassengersMonitoring.Module.Passengers
{
    public class PassengersMonitoringContext : IdentityDbContext<IdentityUser>
    {
        public PassengersMonitoringContext()
            : base()
        {
        }

        public PassengersMonitoringContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Route> Route { get; set; }

        public virtual DbSet<Stop> Stop { get; set; }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("passengersmonitoring");

            modelBuilder.Entity<IdentityUser>(entity => { entity.ToTable(name: "users"); });
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("user_roles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("user_claims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("user_logins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("user_tokens"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("role_claims"); });

            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PassengersMonitoringContext).Assembly);

            modelBuilder.ToSnakeCase();
        }
    }
}
