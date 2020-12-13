using System.Threading.Tasks;
using Hostel.Api.Controllers.Base;
using Hostel.Application.Common.Extensions;
using Hostel.Application.Hostel.Queries.GetHostel;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Api.Controllers
{
    public class HostelController : BaseController
    {
        [HttpGet("hostel")]
        public async Task<IActionResult> Get()
        {
            var hostelId = HttpContext.User.Identity.ExtractHostelId();
            var response = await Mediator.Send(new GetHostelQuery(hostelId));

            return Ok(response);
        }
    }
}