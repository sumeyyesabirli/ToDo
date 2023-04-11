using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAllAsync();
    }
}

