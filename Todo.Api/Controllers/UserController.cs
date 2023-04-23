using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Commands.User.Insert;
using Todo.Core.Controller;

namespace Todo.Api.Controllers
{
    public class UserController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
            => Ok(await Mediator.Send(request));
    }
}
