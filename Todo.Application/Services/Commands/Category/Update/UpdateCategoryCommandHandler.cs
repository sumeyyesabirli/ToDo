using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Commands.Category.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, bool>
    {
        private readonly ICategoryRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //var todoItem = await  _todoItemRepository.GetByIdAsync(request.Id);

            var todoItem = request.Id;

            if (todoItem != null)
            {
                var map = _mapper.Map<Core.Entities.Category>(request);
                var itemRepo = _todoItemRepository.Update(map);
                await _todoItemRepository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
