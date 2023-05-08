using Cmentarz.DAL.Models;
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

        public Grobowiec GetById(int id)
        {
            return _context.Grobowce.Find(id);
        }

        public IEnumerable<Grobowiec> GetAll()
        {
            return _context.Grobowce.ToList();
        }

        public void Add(Grobowiec entity)
        {
            _context.Grobowce.Add(entity);
        }

        public void Update(Grobowiec entity)
        {
            _context.Grobowce.Update(entity);
            SaveChanges(entity);
        }

        public void Delete(Grobowiec entity)
        {
            _context.Grobowce.Remove(entity);
            SaveChanges(entity);
        }   
        public Grobowiec FirstOrDefault(Expression<Func<Grobowiec, bool>> predicate)
        {
            return _context.Grobowce.FirstOrDefault(predicate);
        }

        public bool Any(int id)
        {
            return _context.Grobowce.Any(g => g.IdGrobowiec == id);
        }

        public void SaveChanges(Grobowiec entity)
        {
            _context.SaveChanges();
        }


        public void AddRange(IEnumerable<Grobowiec> entities)
        {
            _context.Grobowce.AddRange(entities);
        }



    }
}
