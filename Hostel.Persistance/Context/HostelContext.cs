using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Hostel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hostel.Persistance.Context
{
    public class HostelContext : DbContext
    {
        public HostelContext(DbContextOptions options): base(options)
        {
            
        }

        #region Hostel Entities
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        #endregion
        
        /// <summary>
        /// for testing soon we can remove it
        /// </summary>
        public DbSet<TestEntity> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
