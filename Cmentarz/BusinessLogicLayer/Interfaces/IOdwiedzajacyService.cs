using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOdwiedzajacyService
    {
        public void DodajOdwiedzajacego(Odwiedzajacy odwiedzajacy);
        public void EdytujOdwiedzajacego(Odwiedzajacy odwiedzajacy);
        public Task<Odwiedzajacy> GetById(int id);
        public IEnumerable<Odwiedzajacy> PobierzWszystkichOdwiedzajacych();
        public IEnumerable<Odwiedzajacy> WyszukajOdwiedzajacych(int idOdwiedzajacy,string imie, string nazwisko);

    }
}
