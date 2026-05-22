
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectTaskManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator =>
            _mediator ??=
            HttpContext.RequestServices
            .GetRequiredService<IMediator>();
    }
}
