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
        public Task Add(UzytkownikRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task Add(Uzytkownik entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UzytkownikRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Uzytkownik entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UzytkownikRepository>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UzytkownikRepository> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UzytkownikRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Uzytkownik entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Uzytkownik>> IRepository<Uzytkownik>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Uzytkownik> IRepository<Uzytkownik>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
