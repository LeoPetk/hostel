﻿// <auto-generated />
using System;
using Hostel.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hostel.Persistance.Migrations
{
    [DbContext(typeof(HostelContext))]
    [Migration("20201111001304_InitTablesAndRelationships")]
    partial class InitTablesAndRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hostel.Domain.Entities.Annotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.Bed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.JoinedEntities.ReservationGuest", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservationId", "GuestId");

                    b.HasIndex("GuestId");

                    b.ToTable("ReservationGuest");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.JoinedEntities.ReservationRoom", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservationId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("ReservationRoom");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.TestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Hostel.Domain.Entities.Bed", b =>
                {
                    b.HasOne("Hostel.Domain.Entities.Room", "Room")
                        .WithMany("Beds")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hostel.Domain.Entities.JoinedEntities.ReservationGuest", b =>
                {
                    b.HasOne("Hostel.Domain.Entities.Guest", "Guest")
                        .WithMany("ReservationGuests")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hostel.Domain.Entities.Reservation", "Reservation")
                        .WithMany("ReservationGuests")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hostel.Domain.Entities.JoinedEntities.ReservationRoom", b =>
                {
                    b.HasOne("Hostel.Domain.Entities.Reservation", "Reservation")
                        .WithMany("ReservationRooms")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hostel.Domain.Entities.Room", "Room")
                        .WithMany("ReservationRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
