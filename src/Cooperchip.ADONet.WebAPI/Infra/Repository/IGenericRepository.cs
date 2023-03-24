using Cooperchip.ADONet.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ADONet.WebAPI.Infra.Repository
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

}
