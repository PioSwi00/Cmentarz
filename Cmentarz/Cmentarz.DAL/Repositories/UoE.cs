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
        public IRepository<Grobowiec> Grobowiec => throw new NotImplementedException();

        public IRepository<OdwiedzajacyRepository> Odwiedzajacy => throw new NotImplementedException();

        public IRepository<UzytkownikRepository> Uzytkownicy => throw new NotImplementedException();

        public IRepository<WlascicielRepository> Wlasciciele => throw new NotImplementedException();

        public IRepository<ZmarlyRepository> Zmarli => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
