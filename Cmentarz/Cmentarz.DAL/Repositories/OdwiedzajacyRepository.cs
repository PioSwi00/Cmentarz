﻿using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;
using System.Linq.Expressions;

namespace Cmentarz.DAL.Repositories
{
    public class OdwiedzajacyRepository : IRepository<Odwiedzajacy>
    {
        private readonly DbCmentarzContext _context;

        public OdwiedzajacyRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task<Odwiedzajacy> GetById(int id)
        {
            return await _context.Odwiedzajacy.FindAsync(id);
        }

        public async Task<IEnumerable<Odwiedzajacy>> GetAll()
        {
            return await _context.Odwiedzajacy.ToListAsync();
        }

        public async Task Add(Odwiedzajacy entity)
        {
            await _context.Odwiedzajacy.AddAsync(entity);
        }

        public async Task Update(Odwiedzajacy entity)
        {
            _context.Odwiedzajacy.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Odwiedzajacy entity)
        {
            _context.Odwiedzajacy.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges(Odwiedzajacy entity)
        {
            await _context.SaveChangesAsync();
        }

        public Task<Odwiedzajacy> FirstOrDefaultAsync(Expression<Func<Odwiedzajacy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        
    }
}
