﻿using System;

namespace Hostel.Domain.Entities.JoinedEntities
{
    public class ReservationGuest
    {
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public Guid GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}