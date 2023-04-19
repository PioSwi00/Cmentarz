using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cmentarz.DAL.Repositories
{
    public class UzytkownikRepository : IRepository<Uzytkownik>
    {
        private readonly DbCmentarzContext _context;

        public UzytkownikRepository(DbCmentarzContext context)
        {
            _context = context;
        }

        public Uzytkownik GetById(int id)
        {
           
           return _context.Uzytkownicy.Find(id);
        }

        public IEnumerable<Uzytkownik> GetAll()
        {
            return _context.Uzytkownicy.ToList();
        }

        public void Add(Uzytkownik entity)
        {
            _context.Uzytkownicy.Add(entity);
        }

        public void Update(Uzytkownik entity)
        {
            _context.Uzytkownicy.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Uzytkownik entity)
        {
            _context.Uzytkownicy.Remove(entity);
            _context.SaveChanges();
        }

        public void SaveChanges(Uzytkownik entity)
        {
            _context.SaveChanges();
        }

        public Uzytkownik FirstOrDefault(Expression<Func<Uzytkownik, bool>> predicate)
        {
            return _context.Uzytkownicy.FirstOrDefault(predicate);
        }

        public bool Any(int id)
        {
            return _context.Uzytkownicy.Any(u => u.IdUzytkownik == id);
        }
    }
}