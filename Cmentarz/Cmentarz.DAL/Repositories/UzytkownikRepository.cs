using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cmentarz.DAL.Repositories
{
    public class UzytkownikRepository : IRepository<Uzytkownik>
    {
        private readonly DbCmentarzContext _context;

        public UzytkownikRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task<Uzytkownik> GetById(int id)
        {
            return await _context.Uzytkownicy.FindAsync(id);
        }

        public async Task<IEnumerable<Uzytkownik>> GetAll()
        {
        
            return await _context.Uzytkownicy.ToListAsync();
        }

        public async Task Add(Uzytkownik entity)
        {
            await _context.Uzytkownicy.AddAsync(entity);
        }

        public async Task Update(Uzytkownik entity)
        {
            _context.Uzytkownicy.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Uzytkownik entity)
        {
            _context.Uzytkownicy.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges(Uzytkownik entity)
        {
            await _context.SaveChangesAsync();
        }    

        public Task<bool> Any(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Uzytkownik> FirstOrDefaultAsync(Expression<Func<Uzytkownik, bool>> predicate)
        {
            return _context.Uzytkownicy.FirstOrDefaultAsync(predicate);
        }
    }
}
