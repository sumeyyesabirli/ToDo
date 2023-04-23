using Todo.Application.Repositories;
using Todo.Core.Entities;
using Todo.Persistence.Contexts;

namespace Todo.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EfDbContext context) : base(context)
        {
        }
    }
}
