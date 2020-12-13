using Hostel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hostel.Persistance.Configuration
{
    public class HostelConfiq : IEntityTypeConfiguration<Domain.Entities.Hostel>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Hostel> builder)
        {
            builder.HasMany<Room>(h => h.Rooms)
                .WithOne(r => r.Hostel)
                .HasForeignKey(r => r.HostelId);
        }
    }
}