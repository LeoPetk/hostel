using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace Hostel.Api.Controllers.Base
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BaseController: ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
