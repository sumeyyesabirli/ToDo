using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Commands.TodoItem.Update
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommandRequest, bool>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateTodoItemCommandRequest request, CancellationToken cancellationToken)
        {

            var todoItem = await  _todoItemRepository.GetByIdAsync(request.Id);

            if (todoItem != null)
            {
                var map = _mapper.Map<Core.Entities.TodoItem>(request);
                var ıtemRepo = _todoItemRepository.Update(map);
                await _todoItemRepository.SaveAsync();
                return true;
            }
            return false;            
        }
    }
}
