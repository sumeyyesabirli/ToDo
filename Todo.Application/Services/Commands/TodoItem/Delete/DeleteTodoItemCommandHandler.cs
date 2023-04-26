using AutoMapper;
using MediatR;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Commands.TodoItem.Delete
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommandRequest, bool>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteTodoItemCommandRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(request.Id);

            if (todoItem != null)
            {
                _todoItemRepository.Delete(todoItem);
                await _todoItemRepository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
