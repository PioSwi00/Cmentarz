using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<Grobowiec> Grobowce { get; }
        IRepository<OdwiedzajacyRepository> Odwiedzajacy { get;}
        IRepository<UzytkownikRepository> Uzytkownicy { get; }
        IRepository<WlascicielRepository> Wlasciciele { get; }
        IRepository<ZmarlyRepository> Zmarli { get; }
        void Save();
    }
}
