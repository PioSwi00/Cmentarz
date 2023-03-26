using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class WlascicielRepository : IRepository<Wlasciciel>
    {
        public Task Add(WlascicielRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task Add(Wlasciciel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(WlascicielRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Wlasciciel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WlascicielRepository>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<WlascicielRepository> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(WlascicielRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Wlasciciel entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Wlasciciel>> IRepository<Wlasciciel>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Wlasciciel> IRepository<Wlasciciel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
