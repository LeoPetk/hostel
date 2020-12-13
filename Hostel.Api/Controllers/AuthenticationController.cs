using System.Threading.Tasks;
using Hostel.Api.Controllers.Base;
using Hostel.Application.Authentication.Commands.LoginUser;
using Hostel.Application.Authentication.Commands.RegisterUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.Api.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var response = await Mediator.Send(command);
            
            return Ok(response);
        }
    }
}