using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassengersMonitoring.Model.Entities;

namespace PassengersMonitoring.Data.Configuration
{
    public class StopConfiguration : IEntityTypeConfiguration<Stop>
    {
        public void Configure(EntityTypeBuilder<Stop> builder)
        {
            builder.ToTable("stop", "passengersmonitoring");

            builder.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.HasIndex(e => e.Id)
                .IsUnique();

            builder.Property(e => e.PassengersNumber)
                .IsRequired();

            builder.Property(e => e.Timestamp)
                .IsRequired();

            builder.Property(e => e.Location)
                .IsRequired()
                .HasColumnType("geometry (point)");
        }
    }
}
