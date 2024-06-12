using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Domain.Common;

namespace ApiSample.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(IList<T> entity);
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
        Task SoftDeleteAsync(T entity);
    }
}
