using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
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
            await _context.Grobowce.AddAsync(entity);
        }

        public async Task Delete(Grobowiec entity)
        {
            await _context.Grobowce.ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Grobowiec>> GetAll()
        {
            
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
