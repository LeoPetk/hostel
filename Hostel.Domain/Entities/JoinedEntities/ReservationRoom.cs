using System;

namespace Hostel.Domain.Entities.JoinedEntities
{
    public class ReservationRoom
    {
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}