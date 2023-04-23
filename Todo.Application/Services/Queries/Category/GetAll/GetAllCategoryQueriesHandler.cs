using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;

namespace Todo.Application.Services.Queries.Category.GetAll
{
    public class GetAllCategoryQueriesHandler : IRequestHandler<GetAllCategoryQueriesRequest,List<GetAllCategoryQueriesResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public  Task<List<GetAllCategoryQueriesResponse>> Handle(GetAllCategoryQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAll =  _categoryRepository.GetAll();
            var map = _mapper.Map<List<GetAllCategoryQueriesResponse>>(getAll);
            return Task.FromResult(map);
        }
    }
}
 