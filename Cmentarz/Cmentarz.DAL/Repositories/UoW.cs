using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;

namespace Cmentarz.DAL.Repositories
{
    public class UoW : IUnitOfWork
    {
        private readonly DbCmentarzContext _context;

        public UoW(DbCmentarzContext context)
        {
            _context = context;
            Grobowce = new GrobowiecRepository(_context);
            Odwiedzajacy = new OdwiedzajacyRepository(_context);
            Uzytkownicy = new UzytkownikRepository(_context);
            Wlasciciele = new WlascicielRepository(_context);
            Zmarli = new ZmarlyRepository(_context);
        }

        public IRepository<Grobowiec> Grobowce { get; }

        public IRepository<Odwiedzajacy> Odwiedzajacy { get; }

        public IRepository<Uzytkownik> Uzytkownicy { get; }

        public IRepository<Wlasciciel> Wlasciciele { get; }

        public IRepository<Zmarly> Zmarli { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}