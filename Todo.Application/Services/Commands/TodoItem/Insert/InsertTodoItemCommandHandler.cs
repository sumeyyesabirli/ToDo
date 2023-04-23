using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Commands.TodoItem.Insert
{
    public class InsertTodoItemCommandHandler : IRequestHandler<InsertTodoItemCommandRequest, bool>
    {
        private readonly ITodoItemRepository  _todoItemRepository;
        private readonly IMapper _mapper;

        public InsertTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public  async Task<bool> Handle(InsertTodoItemCommandRequest request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Core.Entities.TodoItem>(request);
            var userRepo = await _todoItemRepository.AddAsync(map);
            await _todoItemRepository.SaveAsync();
            return true;
        }
    }    
}
