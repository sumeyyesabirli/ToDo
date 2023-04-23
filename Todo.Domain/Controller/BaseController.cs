using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
  
    public abstract class BaseController : ControllerBase
    {
        //protected readonly IMediator _mediator;

        //protected BaseController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
    }
}
