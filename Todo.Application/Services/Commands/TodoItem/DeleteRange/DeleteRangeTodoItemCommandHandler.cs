using AutoMapper;
using MediatR;
using Todo.Application.Repositories;
using Todo.Application.Services.Commands.TodoItem.DeleteRange;

namespace Todo.Application.Services.Commands.TodoItem.DeleteRenge
{
    public class DeleteRangeTodoItemCommandHandler : IRequestHandler<DeleteRangeTodoItemCommandRequest, bool>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public DeleteRangeTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteRangeTodoItemCommandRequest request, CancellationToken cancellationToken)
        {       
            bool status = _todoItemRepository.DeleteRange(request.TodoItems);
            await _todoItemRepository.SaveAsync();
            return status;

        }
    }
}
