using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Commands.Category.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await _categoryRepository.GetByIdAsync(request.Id);

            if (todoItem != null)
            {
                _categoryRepository.Delete(todoItem);
                await _categoryRepository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
