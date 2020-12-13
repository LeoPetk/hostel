using System.Collections.Generic;
using Hostel.Domain.Common;

namespace Hostel.Domain.Entities
{
    public class Hostel : BaseEntity
    {
        public Hostel()
        {
            Rooms = new HashSet<Room>();
        }
        
        public ICollection<Room> Rooms { get; set; }
    }
}