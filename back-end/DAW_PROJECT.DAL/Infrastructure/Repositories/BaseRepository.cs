using DAW_PROJECT.DAL.Entities.Abstraction;
using DAW_PROJECT.DAL.Infrastructure.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext context;

        protected DbSet<T> dbSet;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public T Add(T item)
        {
            try
            {
                dbSet.Add(item);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return item;
        }

        public async Task<T> AddAsysnc(T item)
        {
            try
            {
                dbSet.Add(item);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return item;
        }

        public bool Delete(T item)
        {
            try
            {
                dbSet.Remove(item);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(T item)
        {
            try
            {
                dbSet.Remove(item);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool Exists(int id)
        {
            return dbSet.Any(x => x.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbSet.AnyAsync(x => x.Id == id);
        }

        public IList<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IList<T> GetAll(IEnumerable<int> ids)
        {
            var idSet = ids.ToHashSet();
            return dbSet.Where(x => idSet.Contains(x.Id)).ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(IEnumerable<int> ids)
        {
            var idSet = ids.ToHashSet();
            return await dbSet.Where(x => idSet.Contains(x.Id)).ToListAsync();
        }

        public T GetById(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public T Update(T item)
        {
            try
            {
                dbSet.Update(item);
                context.SaveChanges();
            }
            catch {
                throw;
            }
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                dbSet.Update(item);
                await context.SaveChangesAsync();
            }
            catch {
                throw;
            }
            return item;
        }
    }
}
