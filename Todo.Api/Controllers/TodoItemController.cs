using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Commands.TodoItem.Delete;
using Todo.Application.Services.Commands.TodoItem.Insert;
using Todo.Application.Services.Commands.TodoItem.Update;
using Todo.Application.Services.Queries.TodoItem.GetAll;
using Todo.Core.Controller;

namespace Todo.Api.Controllers
{
    
    public class TodoItemController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> ItemAdd([FromBody] InsertTodoItemCommandRequest request)
             => Ok(await Mediator.Send(request));

        [HttpDelete]
        public async Task<IActionResult> ItemDelete ([FromBody] DeleteTodoItemCommandRequest request)
           => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTodoItemQueriesRequest request)
               => Ok(await Mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTodoItemCommandRequest request)
             => Ok(await Mediator.Send(request));
    }
}
