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
        private DbCmentarzContext _context;
        public UzytkownikRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task Add(Uzytkownik entity)
        {
          await _context.Uzytkownicy.Add(entity);   
        }

        public async Task Delete(Uzytkownik entity)
        {
           await _context.Uzytkownicy.Delete(entity);
        }

        public async Task<IEnumerable<Uzytkownik>> GetAll()
        {
            return await _context.Uzytkownicy.GetAll();
        }

        public async Task<Uzytkownik> GetById(int id)
        {
           return await _context.Uzytkownicy.GetById(id);
        }

        public Task Update(Uzytkownik entity)
        {
           return _context.Uzytkownicy.Update(entity);
        }
    }
}
