using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Core.Enums;

namespace Todo.Application.Services.Queries.TodoItem.GetByFilterPriority
{
    public class GetByFilterPriorityQueriesHandler : IRequestHandler<GetByFilterPriorityQueriesRequest, List<GetByFilterPriorityQueriesResponse>>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;
       

        public GetByFilterPriorityQueriesHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public Task<List<GetByFilterPriorityQueriesResponse>> Handle(GetByFilterPriorityQueriesRequest request, CancellationToken cancellationToken)
        {
           var filteredItems = _todoItemRepository.GetByFilter(x => x.Priority == request.Priority).ToList();
            var map = _mapper.Map<List<GetByFilterPriorityQueriesResponse>>(filteredItems);
            return Task.FromResult(map);
        }
    }
}