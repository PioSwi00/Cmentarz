using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cmentarz.DAL.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Cmentarz.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task SaveChanges(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Any(int id);
   
        

    }
}
