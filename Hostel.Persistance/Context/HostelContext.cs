using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Hostel.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hostel.Persistance.Context
{
    public class HostelContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      
            IgnoreIdentityTables(modelBuilder);
            RenameIdentityTables(modelBuilder);
        }

        private void IgnoreIdentityTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IdentityUserLogin<Guid>>();
            modelBuilder.Ignore<IdentityUserToken<Guid>>();
        }
        
        private void RenameIdentityTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUser<Guid>>().ToTable("Users");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            
        }
    }
}
