using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Queries.User.GetAll
{
    public class GetAllUserQueriesHandler : IRequestHandler<GetAllUserQueriesRequest, List<GetAllUserQueriesResponse>>
    {
        private readonly IUserRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueriesHandler(IUserRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public Task<List<GetAllUserQueriesResponse>> Handle(GetAllUserQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAll = _todoItemRepository.GetAll();
            var map = _mapper.Map<List<GetAllUserQueriesResponse>>(getAll);
            return Task.FromResult(map);
        }
    }
}
