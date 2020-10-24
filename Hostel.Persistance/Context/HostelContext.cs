using System;
using System.Collections.Generic;
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

        public DbSet<TestEntity> Tests { get; set; }
    }
}
