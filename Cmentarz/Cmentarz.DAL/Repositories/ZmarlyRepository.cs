using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Cmentarz.DAL.Models;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Cmentarz.DAL.Repositories
{
    public class ZmarlyRepository : IRepository<Zmarly>
    {
        private readonly DbCmentarzContext _context;
        public ZmarlyRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public Zmarly GetById(int id)
        {
            return _context.Zmarli.Find(id);
        }

        public IEnumerable<Zmarly> GetAll()
        {
            return _context.Zmarli.ToList();
        }

        public void Add(Zmarly entity)
        {
            _context.Zmarli.Add(entity);
        }

        public void Update(Zmarly entity)
        {
            _context.Zmarli.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Zmarly entity)
        {
            _context.Zmarli.Remove(entity);
            _context.SaveChanges();
        }

        public void SaveChanges(Zmarly entity)
        {
            _context.SaveChanges();
        }

        public Zmarly FirstOrDefault(Expression<Func<Zmarly, bool>> predicate)
        {
            return _context.Zmarli.FirstOrDefault(predicate);
        }

        public bool Any(Expression<Func<Zmarly, bool>> predicate)
        {
            return _context.Zmarli.Any(predicate);
        }

        public bool Any(int id)
        {
            return _context.Zmarli.Any(z => z.IdZmarly== id);
        }
    }
}
