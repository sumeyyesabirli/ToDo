using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Commands.Category.Insert
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommandRequest, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public InsertCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async  Task<bool> Handle(InsertCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Core.Entities.Category>(request);
            var userRepo = await _categoryRepository.AddAsync(map);
            await _categoryRepository.SaveAsync();
            return true;
        }
    }
}
