using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Application.Services.Queries.TodoItem.GetAll
{
    public class GetAllTodoItemQueriesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
