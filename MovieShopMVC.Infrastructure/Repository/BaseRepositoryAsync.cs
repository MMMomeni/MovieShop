using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Contracts.Repository;
using MovieShopMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly MovieShopDbContext DbContext;

        public BaseRepositoryAsync(MovieShopDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await DbContext.Set<T>().FindAsync(id);
            DbContext.Set<T>().Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
            
        }

        public async Task<int> InsertAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            DbContext.Entry<T>(entity).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }
    }
}
