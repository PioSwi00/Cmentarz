using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGrobowiecService
    {
    
        IEnumerable<Grobowiec> PobierzWszystkieGrobowce();
        public Grobowiec GetGrobowceFilteredById(int id);
        public void DodajZmarlegoDoGrobowca(int idGrobowca, Zmarly zmarly);
        public List<Grobowiec> WyszukajGroby(int? idGrobu, int? idWlasciciel, string? lokalizacja, decimal? cena, String? Sektor);
        public int IloscOdwiedzajacych(int idGrobowca);
        public IEnumerable<Grobowiec> PobierzWolneGroby();
        public IEnumerable<Grobowiec> PobierzZajeteGroby();
        public IEnumerable<Grobowiec> PobierzGrobyWlasciciela(int idWlasciciela);
        public void DodajGrobowiec(Grobowiec grobowiec);
        public void DodajOdwiedzajacegoDoGrobowca(int idGrobowca, int idOdwiedzajacego);
        public void UsunOdwiedzajacegoZGrobowca(int idGrobowca, int idOdwiedzajacego);
        public IEnumerable<Odwiedzajacy> PobierzOdwiedzajacychGrobowce(int idGrobowca);

        public IEnumerable<Zmarly> PobierzZmarlychWGrobie(int idGrobowca);



    }
}
