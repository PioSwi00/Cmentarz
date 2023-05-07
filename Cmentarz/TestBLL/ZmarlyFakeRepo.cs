using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class ZmarlyFakeRepo : IRepository<Zmarly>
    {
        private readonly List<Zmarly> _zmarli;
        public ZmarlyFakeRepo()
        {
            _zmarli = new List<Zmarly>();
        }

        public Zmarly GetById(int id)
        {
            return _zmarli.FirstOrDefault(z => z.IdZmarly == id);
        }

        public IEnumerable<Zmarly> GetAll()
        {
            return _zmarli;
        }

        public void Add(Zmarly entity)
        {
            entity.IdZmarly = _zmarli.Count + 1;
            _zmarli.Add(entity);
        }

        public void Update(Zmarly entity)
        {
            var existingEntity = GetById(entity.IdZmarly);
            if (existingEntity != null)
            {
                existingEntity.Imie = entity.Imie;
                existingEntity.Nazwisko = entity.Nazwisko;
                existingEntity.DataUrodzenia = entity.DataUrodzenia;
             
            }
        }

        public void Delete(Zmarly entity)
        {
            var existingEntity = GetById(entity.IdZmarly);
            if (existingEntity != null)
            {
                _zmarli.Remove(existingEntity);
            }
        }

        public Zmarly FirstOrDefault(Expression<Func<Zmarly, bool>> predicate)
        {
            return _zmarli.AsQueryable().FirstOrDefault(predicate);
        }

        public bool Any(int id)
        {
            return _zmarli.Any(z => z.IdZmarly == id);
        }

        public bool Any(Expression<Func<Zmarly, bool>> predicate)
        {
            return _zmarli.AsQueryable().Any(predicate);
        }

        public void SaveChanges(Zmarly entity)
        {
           /////
        }
    }
}

