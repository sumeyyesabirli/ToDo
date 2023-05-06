using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Queries.User.GetAll
{
    public class GetAllUserQueriesRequest : IRequest<List<GetAllUserQueriesResponse>>
    {
    }
}
