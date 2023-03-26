using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class ZmarlyRepository : IRepository<Zmarly>
    {
        public Task Add(Zmarly entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Zmarly entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zmarly>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Zmarly> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Zmarly entity)
        {
            throw new NotImplementedException();
        }
    }
}
