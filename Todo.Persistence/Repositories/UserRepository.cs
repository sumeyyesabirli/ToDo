using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Core.Entities;

namespace Todo.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
