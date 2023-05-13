using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Commands.User.Insert;
using Todo.Application.Services.Commands.User.Login;
using Todo.Application.Services.Queries.User.GetAll;
using Todo.Core.Controller;

namespace Todo.Api.Controllers
{
    public class UserController : BaseController
    {

       [HttpPost]
       public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
           => Ok(await Mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
           => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQueriesRequest request)
             => Ok(await Mediator.Send(request));
    }
}
