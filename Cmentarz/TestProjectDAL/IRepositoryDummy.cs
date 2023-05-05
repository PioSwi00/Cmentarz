using Cmentarz.DAL.Repositories;

namespace TestProjectDAL
{
    public class IRepositoryDummy<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}