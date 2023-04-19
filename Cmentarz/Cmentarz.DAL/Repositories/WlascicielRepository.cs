using Cmentarz.Models;
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
    public class WlascicielRepository : IRepository<Wlasciciel>
    {
        private readonly DbCmentarzContext _context;

        public WlascicielRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public Wlasciciel GetById(int id)
        {
            return _context.Wlasciciele.Find(id);
        }

        public IEnumerable<Wlasciciel> GetAll()
        {
            return _context.Wlasciciele.ToList();
        }

        public void Add(Wlasciciel entity)
        {
            _context.Wlasciciele.Add(entity);
        }

        public void Update(Wlasciciel entity)
        {
            _context.Wlasciciele.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Wlasciciel entity)
        {
            _context.Wlasciciele.Remove(entity);
            _context.SaveChanges();
        }

        public void SaveChanges(Wlasciciel entity)
        {
            _context.SaveChanges();
        }

        public Wlasciciel FirstOrDefault(Expression<Func<Wlasciciel, bool>> predicate)
        {
            return _context.Wlasciciele.FirstOrDefault(predicate);
        }

        public bool Any(int id)
        {
            return _context.Wlasciciele.Any(w => w.IdWlasciciel == id);
        }


    }
}
