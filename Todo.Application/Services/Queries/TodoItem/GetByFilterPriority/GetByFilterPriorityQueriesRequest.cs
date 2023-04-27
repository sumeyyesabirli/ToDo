using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Enums;

namespace Todo.Application.Services.Queries.TodoItem.GetByFilterPriority
{
    public class GetByFilterPriorityQueriesRequest : IRequest<List<GetByFilterPriorityQueriesResponse>>
    {
         public Priority? Priority { get; set; }
    }
}
