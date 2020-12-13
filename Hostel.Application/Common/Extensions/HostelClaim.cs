using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Hostel.Application.Common.Extensions
{
    public static class HostelClaim
    {
        public static Guid ExtractHostelId(this IIdentity identity)
        {
            if (!(identity is ClaimsIdentity claimsIdentity)) return Guid.Empty;
            var hostelId = Guid.Parse(claimsIdentity.Claims.FirstOrDefault(x => x.Type == "HostelId")?.Value ?? Guid.Empty.ToString());

            return hostelId;
        }
    }
}