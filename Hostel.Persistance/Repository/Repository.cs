using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hostel.Application.Common.Repository;
using Hostel.Domain.Entities;
using Hostel.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Hostel.Persistance.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly HostelContext _context;
        private readonly DbSet<T> _table;

        public Repository(HostelContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByAsync(Expression<Func<T,bool>> expression)
        {
            return await _table.AsNoTracking().SingleOrDefaultAsync(expression);
        }
        
        public void Add(T entity) 
        {
            _table.Add(entity);
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid entityId)
        {
            var entity = await _table.FindAsync(entityId);
            _table.Remove(entity);
        }

        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }
    }
}
