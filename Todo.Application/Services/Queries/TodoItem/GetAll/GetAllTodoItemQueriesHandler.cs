using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Application.Services.Commands.TodoItem.Insert;

namespace Todo.Application.Services.Queries.TodoItem.GetAll
{
    public class GetAllTodoItemQueriesHandler : IRequestHandler<GetAllTodoItemQueriesRequest, List<GetAllTodoItemQueriesResponse>>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public GetAllTodoItemQueriesHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public Task<List<GetAllTodoItemQueriesResponse>> Handle(GetAllTodoItemQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAll = _todoItemRepository.GetAll();
            var map = _mapper.Map<List<GetAllTodoItemQueriesResponse>>(getAll);
            return Task.FromResult(map);
        }
    }
}
