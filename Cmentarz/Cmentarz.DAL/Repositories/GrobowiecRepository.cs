using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class GrobowiecRepository : IRepository<Grobowiec>
    {
        public Task Add(Grobowiec entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Grobowiec entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grobowiec>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Grobowiec> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Grobowiec entity)
        {
            throw new NotImplementedException();
        }
    }
}
