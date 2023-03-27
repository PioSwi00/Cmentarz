using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;
namespace Cmentarz.DAL.Repositories
{
    internal class WlascicielRepository : IRepository<Wlasciciel>
    {
        private readonly DbCmentarzContext _context;

        public WlascicielRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task<Wlasciciel> GetById(int id)
        {
            return await _context.Wlasciciele.FindAsync(id);
        }

        public async Task<IEnumerable<Wlasciciel>> GetAll()
        {
            return await _context.Wlasciciele.ToListAsync();
        }

        public async Task Add(Wlasciciel entity)
        {
            await _context.Wlasciciele.AddAsync(entity);
        }

        public async Task Update(Wlasciciel entity)
        {
            _context.Wlasciciele.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Wlasciciel entity)
        {
            _context.Wlasciciele.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
