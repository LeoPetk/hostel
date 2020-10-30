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

        public Repository(HostelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
