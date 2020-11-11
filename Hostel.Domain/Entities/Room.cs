using System.Collections.Generic;
using Hostel.Domain.Common;
using Hostel.Domain.Entities.JoinedEntities;

namespace Hostel.Domain.Entities
{
    public class Room : BaseEntity
    {
        public Room()
        {
            Beds= new HashSet<Bed>();
            ReservationRooms= new HashSet<ReservationRoom>();
        }
        public ICollection<Bed> Beds { get; set; }
        public ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}