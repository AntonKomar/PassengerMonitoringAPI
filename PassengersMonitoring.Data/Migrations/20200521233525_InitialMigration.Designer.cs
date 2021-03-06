// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PassengersMonitoring.Module.Passengers;

namespace PassengersMonitoring.Data.Migrations
{
    [DbContext(typeof(PassengersMonitoringContext))]
    [Migration("20200521233525_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("passengersmonitoring")
                .HasAnnotation("Npgsql:PostgresExtension:postgis", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PassengersMonitoring.Model.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnName("location")
                        .HasColumnType("geometry (point)");

                    b.Property<int>("OrderNumber")
                        .HasColumnName("order_number")
                        .HasColumnType("integer");

                    b.Property<int>("RouteNumber")
                        .HasColumnName("route_number")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_route");

                    b.HasAlternateKey("RouteNumber")
                        .HasName("ak_route_route_number");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("ix_route_id");

                    b.HasIndex("RouteNumber")
                        .HasName("ix_route_route_number");

                    b.ToTable("route","passengersmonitoring");
                });

            modelBuilder.Entity("PassengersMonitoring.Model.Entities.Stop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnName("location")
                        .HasColumnType("geometry (point)");

                    b.Property<int>("PassengersNumber")
                        .HasColumnName("passengers_number")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("VehicleId")
                        .HasColumnName("vehicle_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_stop");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("ix_stop_id");

                    b.HasIndex("VehicleId")
                        .HasName("ix_stop_vehicle_id");

                    b.ToTable("stop","passengersmonitoring");
                });

            modelBuilder.Entity("PassengersMonitoring.Model.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("RouteNumber")
                        .HasColumnName("route_number")
                        .HasColumnType("integer");

                    b.Property<int>("SitsNumber")
                        .HasColumnName("sits_number")
                        .HasColumnType("integer")
                        .HasMaxLength(1000);

                    b.Property<int>("VehicleModel")
                        .HasColumnName("vehicle_model")
                        .HasColumnType("integer")
                        .HasMaxLength(500);

                    b.HasKey("Id")
                        .HasName("pk_vehicle");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("ix_vehicle_id");

                    b.HasIndex("RouteNumber")
                        .HasName("ix_vehicle_route_number");

                    b.ToTable("vehicle","passengersmonitoring");
                });

            modelBuilder.Entity("PassengersMonitoring.Model.Entities.Stop", b =>
                {
                    b.HasOne("PassengersMonitoring.Model.Entities.Vehicle", null)
                        .WithMany("StopsHistory")
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("fk_stop_vehicle_vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassengersMonitoring.Model.Entities.Vehicle", b =>
                {
                    b.HasOne("PassengersMonitoring.Model.Entities.Route", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("RouteNumber")
                        .HasConstraintName("fk_vehicle_route_route_number")
                        .HasPrincipalKey("RouteNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
