using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUzytkownikService
    {
        public Uzytkownik Login(string login, string haslo);
        public IEnumerable<Uzytkownik> SortujUzytkownikow();
        public void KupGrobowiec(int idUzytkownik, int idGrobowiec);

    }
}
