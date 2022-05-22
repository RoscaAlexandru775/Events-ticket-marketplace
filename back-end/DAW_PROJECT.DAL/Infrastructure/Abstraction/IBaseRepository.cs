using DAW_PROJECT.DAL.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Infrastructure.Abstraction
{
    public  interface IBaseRepository<T> where T: IEntity 
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();
        IList<T> GetAll(IEnumerable<int> ids);
        Task<IList<T>> GetAllAsync(IEnumerable<int> ids);
        bool Exists(int id);
        Task<bool> ExistsAsync(int id);
        T Add(T item);
        Task<T> AddAsysnc(T item);
        T Update(T item);
        Task<T> UpdateAsync(T item);
        bool Delete(T item);
        Task<bool> DeleteAsync(T item);
    }
}
