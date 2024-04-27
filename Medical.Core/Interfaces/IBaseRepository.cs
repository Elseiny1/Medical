using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();

        T Update(T entity);

        T Delete(T entity);
    }
}
