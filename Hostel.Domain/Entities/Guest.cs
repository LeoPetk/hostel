using System.Collections.Generic;
using Hostel.Domain.Common;
using Hostel.Domain.Entities.JoinedEntities;

namespace Hostel.Domain.Entities
{
    public class Guest : BaseEntity
    {
        public Guest()
        {
            ReservationGuests = new HashSet<ReservationGuest>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOwner { get; set; }
        public ICollection<ReservationGuest> ReservationGuests { get; set; }
    }
}