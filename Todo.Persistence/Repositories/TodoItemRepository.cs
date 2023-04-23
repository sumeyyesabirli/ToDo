using Todo.Application.Repositories;
using Todo.Core.Entities;
using Todo.Persistence.Contexts;

namespace Todo.Persistence.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(EfDbContext context) : base(context)
        {
        }
    }
}
