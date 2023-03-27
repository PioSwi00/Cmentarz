using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class ZmarlyRepository : IRepository<Zmarly>
    {
        private readonly DbCmentarzContext _context;
        public ZmarlyRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task<Zmarly> GetById(int id)
        {
            return await _context.Zmarli.FindAsync(id);
        }

        public async Task<IEnumerable<Zmarly>> GetAll()
        {
            return await _context.Zmarli.ToListAsync();
        }

        public async Task Add(Zmarly entity)
        {
            await _context.Zmarli.AddAsync(entity);
        }

        public async Task Update(Zmarly entity)
        {
            _context.Zmarli.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Zmarly entity)
        {
            _context.Zmarli.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
