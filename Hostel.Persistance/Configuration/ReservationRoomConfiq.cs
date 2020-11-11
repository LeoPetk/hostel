using Hostel.Domain.Entities;
using Hostel.Domain.Entities.JoinedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hostel.Persistance.Configuration
{
    public class ReservationRoomConfiq : IEntityTypeConfiguration<ReservationRoom>
    {
        public void Configure(EntityTypeBuilder<ReservationRoom> builder)
        {
            builder.HasKey(r => new { r.ReservationId, r.RoomId});
            
            builder.HasOne(r => r.Reservation)
                .WithMany(r => r.ReservationRooms)
                .HasForeignKey(r => r.ReservationId);
            
            builder.HasOne(r => r.Room)
                .WithMany(r => r.ReservationRooms)
                .HasForeignKey(r => r.RoomId);
        }
    }
}