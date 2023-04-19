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
    public class OdwiedzajacyRepository : IRepository<Odwiedzajacy>
    {
        private readonly DbCmentarzContext _context;

        public OdwiedzajacyRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public Odwiedzajacy GetById(int id)
        {
            return _context.Odwiedzajacy.Find(id);
        }

        public IEnumerable<Odwiedzajacy> GetAll()
        {
            return _context.Odwiedzajacy.ToList();
        }

        public void Add(Odwiedzajacy entity)
        {
            _context.Odwiedzajacy.Add(entity);
        }

        public void Update(Odwiedzajacy entity)
        {
            _context.Odwiedzajacy.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Odwiedzajacy entity)
        {
            _context.Odwiedzajacy.Remove(entity);
            _context.SaveChanges();
        }

        public void SaveChanges(Odwiedzajacy entity)
        {
            _context.SaveChanges();
        }

        public Odwiedzajacy FirstOrDefault(Expression<Func<Odwiedzajacy, bool>> predicate)
        {
            return _context.Odwiedzajacy.FirstOrDefault(predicate);
        }

        public bool Any(int id)
        {
            return _context.Odwiedzajacy.Any(o => o.IdOdwiedzajacy == id);
        }
    }
}