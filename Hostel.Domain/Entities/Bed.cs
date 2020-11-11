using System;
using Hostel.Domain.Common;

namespace Hostel.Domain.Entities
{
    public class Bed : BaseEntity
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}