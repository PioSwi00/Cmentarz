﻿using Cmentarz.DAL.Models;
using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Cmentarz.DAL.Repositories
{
    public class GrobowiecRepository : IRepository<Grobowiec>
    {
        private readonly DbCmentarzContext _context;

        public GrobowiecRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public async Task<Grobowiec> GetById(int id)
        {
            return await _context.Grobowce.FindAsync(id);
        }

        public async Task<IEnumerable<Grobowiec>> GetAll()
        {
            return await _context.Grobowce.ToListAsync();
        }

        public async Task Add(Grobowiec entity)
        {
            await _context.Grobowce.AddAsync(entity);
        }

        public async Task Update(Grobowiec entity)
        {
            _context.Grobowce.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Grobowiec entity)
        {
            _context.Grobowce.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges(Grobowiec entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Grobowiec> FirstOrDefaultAsync(Expression<Func<Grobowiec, bool>> predicate)
        {
            return await _context.Grobowce.FirstOrDefaultAsync(predicate);
        }


        public async Task<bool> Any(int id)
        {
            return await _context.Grobowce.AnyAsync(g => g.IdGrobowiec == id);
        }
    }
}
