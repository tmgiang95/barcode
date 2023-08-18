using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.Repository
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        DbSet<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<bool> BulkAsync(List<T> entities);
        Task<bool> BulkUpdateAsync(List<T> entities);
        IQueryable<T> SqlQuery(string sql, params object[] parameters);
        IEnumerable<T> GetwithIncludeAsync(string entityType);
        IQueryable<T> Query();
    }
}
