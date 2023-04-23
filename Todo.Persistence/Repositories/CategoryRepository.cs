using Todo.Application.Repositories;
using Todo.Core.Entities;
using Todo.Persistence.Contexts;

namespace Todo.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EfDbContext context) : base(context)
        {
        }
    }
}
