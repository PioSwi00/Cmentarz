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
        IRepository<Odwiedzajacy> Odwiedzajacy { get;}
        IRepository<Uzytkownik> Uzytkownicy { get; }
        IRepository<Wlasciciel> Wlasciciele { get; }
        IRepository<Zmarly> Zmarli { get; }
    }
}
