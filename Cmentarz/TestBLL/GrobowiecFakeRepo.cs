using Cmentarz.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class GrobowiecFakeRepo
    {

        private readonly List<Grobowiec> _grobowce;
        public GrobowiecFakeRepo()
        {
            _grobowce = new List<Grobowiec>();
        }


        public Grobowiec GetById(int id)
        {
            return _grobowce.FirstOrDefault(g => g.IdGrobowiec == id);
        }

        public IEnumerable<Grobowiec> GetAll()
        {
            return _grobowce;
        }

        public void Add(Grobowiec entity)
        {
            entity.IdGrobowiec = _grobowce.Count + 1;
            _grobowce.Add(entity);
        }

        public void Update(Grobowiec entity)
        {
            var existingEntity = GetById(entity.IdGrobowiec);
            if (existingEntity != null)
            {
                existingEntity.IdWlasciciel = entity.IdWlasciciel;
                existingEntity.IdGrobowiec = entity.IdGrobowiec;
            }
        }

        public void Delete(Grobowiec entity)
        {
            var existingEntity = GetById(entity.IdGrobowiec);
            if (existingEntity != null)
            {
                _grobowce.Remove(existingEntity);
            }
        }

        public Grobowiec FirstOrDefault(Expression<Func<Grobowiec, bool>> predicate)
        {
            return _grobowce.AsQueryable().FirstOrDefault(predicate);
        }

        public bool Any(int id)
        {
            return _grobowce.Any(g => g.IdGrobowiec == id);
        }

    }
}
