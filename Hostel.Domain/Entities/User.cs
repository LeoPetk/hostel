using System;
using Microsoft.AspNetCore.Identity;

namespace Hostel.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid HostelId { get; set; }
    }
}