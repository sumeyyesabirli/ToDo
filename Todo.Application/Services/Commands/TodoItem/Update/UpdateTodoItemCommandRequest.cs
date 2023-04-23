using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Commands.TodoItem.Update
{
    public class UpdateTodoItemCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? UserId { get; set; }
    }
}
