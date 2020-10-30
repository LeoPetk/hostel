using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hostel.Domain.Entities;

namespace Hostel.Application.Common.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAsync();
        void Add<T>(T entity);
        void Delete<T>(T entity);
        Task<bool> SaveAll();
    }
}
