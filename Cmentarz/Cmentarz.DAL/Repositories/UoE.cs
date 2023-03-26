using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class UoE : IUnitOfWork
    {
        private DbCmentarzContext _context;

        public IRepository<Grobowiec> Grobowce => throw new NotImplementedException();

        public IRepository<Odwiedzajacy> Odwiedzajacy => throw new NotImplementedException();

        public IRepository<Uzytkownik> Uzytkownicy => throw new NotImplementedException();

        public IRepository<Wlasciciel> Wlasciciele => throw new NotImplementedException();

        public IRepository<Zmarly> Zmarli => throw new NotImplementedException();

        public IRepository<Grobowiec> Grobowiec => throw new NotImplementedException();

        private bool dispose = false;
        public virtual void Dispose(bool dispose)
        {
            if (!this.dispose)
            {
                if(dispose)
                {
                   
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
