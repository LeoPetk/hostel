using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hostel.Domain.Entities;

namespace Hostel.Application.Common.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByAsync(Expression<Func<T,bool>> expression);
        Task<IEnumerable<T>> GetListByAsync(Expression<Func<T,bool>> expression);
        void Add(T entity);
        void Update(T entity);
        Task DeleteAsync (Guid entityId);
        Task SaveAsync();
    }
}
