using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Core.Entities;
using Todo.Persistence.Contexts;

namespace Todo.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly EfDbContext _context;

        public BaseRepository(EfDbContext context)
        {
            _context = context;
        }       
        public async Task<bool> AddAsync(T entity)
        {
           EntityEntry<T> entityEntry= await _context.AddAsync(entity);
           return entityEntry.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = _context.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool DeleteRenge(List<T> entity)
        {
            _context.RemoveRange(entity);
            return true;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return  await _context.Set<T>().FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(method);
        }
       
        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = _context.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
