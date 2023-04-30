using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Commands.TodoItem.DeleteRange
{
    public class DeleteRangeTodoItemCommandRequest : IRequest<bool>
    {
       public List<Todo.Core.Entities.TodoItem> TodoItems { get; set; }
    }
}
