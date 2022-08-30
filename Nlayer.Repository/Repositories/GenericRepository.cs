using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dBset;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dBset = _context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await _dBset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dBset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dBset.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dBset.AsNoTracking().AsQueryable(); 
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dBset.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dBset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dBset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dBset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dBset.Where(expression);
        }

       
    }
}
