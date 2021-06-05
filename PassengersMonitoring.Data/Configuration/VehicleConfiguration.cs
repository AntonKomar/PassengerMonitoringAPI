using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassengersMonitoring.Common;
using PassengersMonitoring.Model.Entities;

namespace PassengersMonitoring.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("vehicle", "passengersmonitoring");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.HasIndex(e => e.Id)
                .IsUnique();

            builder.Property(e => e.VehicleModel)
                .IsRequired()
                .HasMaxLength(PropertyLengthLimitation.MediumLarge);

            builder.Property(e => e.RouteNumber)
                .IsRequired();

            builder.Property(e => e.SitsNumber)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasMany(d => d.StopsHistory)
                 .WithOne()
                 .HasPrincipalKey(p => p.Id)
                 .HasForeignKey(d => d.VehicleId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
