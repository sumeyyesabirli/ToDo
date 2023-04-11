using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
