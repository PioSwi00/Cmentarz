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
        public List<Grobowiec> WyszukajGroby(int idGrobu, int idWlasciciel, string lokalizacja, decimal cena);
        public int IloscOdwiedzajacych(int idGrobowca);
    }
}
