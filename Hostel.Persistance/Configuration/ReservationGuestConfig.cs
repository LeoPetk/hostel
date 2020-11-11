using Hostel.Domain.Entities.JoinedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hostel.Persistance.Configuration
{
    public class ReservationGuestConfig : IEntityTypeConfiguration<ReservationGuest>
    {
        public void Configure(EntityTypeBuilder<ReservationGuest> builder)
        {
            builder.HasKey(r => new { r.ReservationId, r.GuestId});
            
            builder.HasOne(r => r.Reservation)
                .WithMany(r => r.ReservationGuests)
                .HasForeignKey(r => r.ReservationId);
            
            builder.HasOne(r => r.Guest)
                .WithMany(r => r.ReservationGuests)
                .HasForeignKey(r => r.GuestId);
        }
    }
}