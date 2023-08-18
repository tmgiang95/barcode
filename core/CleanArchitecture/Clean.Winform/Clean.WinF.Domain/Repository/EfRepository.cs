using Clean.WinF.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.Repository
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        private BlueprintContext _dbContext;

        public EfRepository(BlueprintContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> BulkUpdateAsync(List<T> entities)
        {
            try
            {
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (var entityToInsert in entities)
                {
                    _dbContext.Entry(entityToInsert).State = EntityState.Modified;
                }

                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> BulkAsync(List<T> entities)
        {
            try
            {
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await _dbContext.AddRangeAsync(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public DbSet<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> SqlQuery(string sql, params object[] parameters)
        {
            return _dbContext.Set<T>().FromSqlRaw(sql, parameters);
        }

        public IEnumerable<T> GetwithIncludeAsync(string entityType)
        {
            return _dbContext.Set<T>().Include(entityType).ToList();
        }

        public virtual IQueryable<T> Query()
        {
            return _dbContext.Set<T>();
        }
    }
}
