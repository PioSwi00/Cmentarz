using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class UzytkownikRepository : IRepository<Uzytkownik>
    {
        public Task Add(Uzytkownik entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Uzytkownik entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Uzytkownik>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Uzytkownik> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Uzytkownik entity)
        {
            throw new NotImplementedException();
        }
    }
}
