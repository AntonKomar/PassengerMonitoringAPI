using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassengersMonitoring.Model.Entities;

namespace PassengersMonitoring.Data.Configuration
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("route", "passengersmonitoring");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.HasIndex(e => e.Id)
                .IsUnique();

            builder.Property(e => e.RouteNumber)
                .IsRequired();

            builder.HasIndex(e => e.RouteNumber);

            builder.Property(e => e.OrderNumber)
                .IsRequired();

            builder.Property(e => e.Location)
                .IsRequired()
                .HasColumnType("geometry (point)");

            builder.HasMany(d => d.Vehicles)
                 .WithOne()
                 .HasPrincipalKey(p => p.RouteNumber)
                 .HasForeignKey(d => d.RouteNumber)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
