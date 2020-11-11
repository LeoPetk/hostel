using System;
using System.Collections.Generic;
using Hostel.Domain.Common;
using Hostel.Domain.Entities.JoinedEntities;

namespace Hostel.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public Reservation()
        {
            ReservationRooms = new HashSet<ReservationRoom>();
            ReservationGuests = new HashSet<ReservationGuest>();
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ICollection<ReservationGuest> ReservationGuests { get; set; }
        public ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}