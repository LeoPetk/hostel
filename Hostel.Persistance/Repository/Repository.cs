using System;
using System.Collections.Generic;
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
            return await _table.ToListAsync();
        }

        public void Add(T entity) 
        {
            _table.Add(entity);
        }

        public async Task<T> GetById(Guid entityId)
        {
            return await _table.FindAsync(entityId);
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(Guid entityId)
        {
            var entity = await _table.FindAsync(entityId);
            _table.Remove(entity);
        }

        public async Task Save()
        {
             await _context.SaveChangesAsync();
        }
    }
}
