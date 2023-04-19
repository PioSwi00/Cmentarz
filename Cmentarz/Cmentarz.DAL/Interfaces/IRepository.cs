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
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges(TEntity entity);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        
   
        

    }
}
