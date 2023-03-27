using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cmentarz.DAL.Models;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

    }
}
