using Clean.WinF.Domain.IRepository;
using Clean.WinF.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Repositories
{
    public class EFRepository<T>: IAsyncRepository<T> where T : class
    {
        private ApplicationDBContext _appDBContext;
        public EFRepository(ApplicationDBContext dbContext)
        {
            _appDBContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _appDBContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _appDBContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _appDBContext.Set<T>().Remove(entity);
            await _appDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _appDBContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _appDBContext.Entry(entity).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> BulkUpdateAsync(List<T> entities)
        {
            try
            {
                _appDBContext.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (var entityToInsert in entities)
                {
                    _appDBContext.Entry(entityToInsert).State = EntityState.Modified;
                }

                await _appDBContext.SaveChangesAsync();
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
                _appDBContext.ChangeTracker.AutoDetectChangesEnabled = false;
                await _appDBContext.AddRangeAsync(entities);
                await _appDBContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public DbSet<T> GetAll()
        {
            return _appDBContext.Set<T>();
        }

        public IQueryable<T> SqlQuery(string sql, params object[] parameters)
        {
            return _appDBContext.Set<T>().FromSqlRaw(sql, parameters);
        }

        public IEnumerable<T> GetwithIncludeAsync(string entityType)
        {
            return _appDBContext.Set<T>().Include(entityType).ToList();
        }

        public virtual IQueryable<T> Query()
        {
            return _appDBContext.Set<T>();
        }
    }
}
