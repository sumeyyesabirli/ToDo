using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Commands.Category.Delete;
using Todo.Application.Services.Commands.Category.Insert;
using Todo.Application.Services.Commands.Category.Update;
using Todo.Application.Services.Queries.Category.GetAll;
using Todo.Core.Controller;

namespace Todo.Api.Controllers
{
    
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] InsertCategoryCommandRequest request)
            => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQueriesRequest request)
              => Ok(await Mediator.Send(request));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommandRequest request)
           => Ok(await Mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request)
             => Ok(await Mediator.Send(request));
    }
}
