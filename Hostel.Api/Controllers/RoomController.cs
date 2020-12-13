using System.Security.Claims;
using System.Threading.Tasks;
using Hostel.Api.Controllers.Base;
using Hostel.Application.Common.Extensions;
using Hostel.Application.Room.Queries.GetRooms;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Api.Controllers
{
    public class RoomController : BaseController
    {
        [HttpGet("rooms")]
        public async Task<IActionResult> Get()
        {
            var hostelId = HttpContext.User.Identity.ExtractHostelId();
            var response = await Mediator.Send(new GetRoomsQuery(hostelId));
            
            return Ok(response);
        }
    }
}