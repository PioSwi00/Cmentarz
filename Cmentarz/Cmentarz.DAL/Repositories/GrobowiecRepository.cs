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
        private DbCmentarzContext _context;
        public GrobowiecRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task Add(Grobowiec entity)
        {
          await _context.Grobowce.Add(entity);
        }

        public async Task Delete(Grobowiec entity)
        {
            await _context.Grobowce.Delete(entity);
          
        }

        public async Task<IEnumerable<Grobowiec>> GetAll()
        {
            return await _context.Grobowce.GetAll();
        }

        public async Task<Grobowiec> GetById(int id)
        {
            return await _context.Grobowce.GetById(id);
        }
        public Task Update(Grobowiec entity)
        {
            return _context.Grobowce.Update(entity);
        }
    }
}
