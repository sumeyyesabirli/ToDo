using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Queries.Category.GetAll
{
    public class GetAllCategoryQueriesRequest : IRequest<List<GetAllCategoryQueriesResponse>>
    {
      
    }
}
