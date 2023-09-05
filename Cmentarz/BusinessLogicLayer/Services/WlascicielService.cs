using Azure;
using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class WlascicielService : IWlascicielService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WlascicielService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Wlasciciel> GetWlasciciele()
        {
            var wlasciciele = _unitOfWork.Wlasciciele.GetAll();
            return wlasciciele;
        }
        public IEnumerable<Wlasciciel> GetByNazwisko(string nazwisko)
        {
            var wlasciciele = _unitOfWork.Wlasciciele.GetAll();
            return wlasciciele.Where(w => w.Nazwisko.ToLower().Contains(nazwisko.ToLower()));
        }
        public IEnumerable<Wlasciciel> WlascicielGetByOrder(string sortBy)
        {
            IEnumerable<Wlasciciel> wlasciciele = _unitOfWork.Wlasciciele.GetAll();

            switch (sortBy)
            {
                case "Imie":
                    wlasciciele = wlasciciele.OrderBy(w => w.Imie);
                    break;
                case "Nazwisko":
                    wlasciciele = wlasciciele.OrderBy(w => w.Nazwisko);
                    break;
                default:
                    wlasciciele = wlasciciele.OrderBy(w => w.IdWlasciciel);
                    break;
            }

            return wlasciciele;
        }

        public Wlasciciel GetWlascicielById(int id)
        {
            var wlasciciel = _unitOfWork.Wlasciciele.GetById(id);
            return wlasciciel;
        }

        public void DodajWlasciciela(Wlasciciel wlasciciel)
        {

            var istnieje = _unitOfWork.Wlasciciele.FirstOrDefault(w => w.IdWlasciciel == wlasciciel.IdWlasciciel);

            if (istnieje != null)
            {
                throw new Exception("Wlasciciel o podanym id już istnieje.");
            }


            _unitOfWork.Wlasciciele.Add(wlasciciel);
            _unitOfWork.Save();
        }

        /* Dobry pomysł słabe wykonanie
        public IEnumerable<(Odwiedzajacy odwiedzajacy, IEnumerable<Zmarly> zmarli)> ListaOdwiedzajacychIGrobowca(int idGrobowca)
        {
            var grobowiec = _unitOfWork.Grobowce.GetById(idGrobowca);

            var odwiedzajacy = _unitOfWork.Odwiedzajacy.GetAll();

            var zmarli = new List<IEnumerable<Zmarly>>();

            foreach (var pochowany in grobowiec.Zmarli.ToList())
            {
                var listaZmarlych = _unitOfWork.Zmarli.GetById(pochowany.IdZmarly);

                zmarli.Add((IEnumerable<Zmarly>)listaZmarlych);
            }

            var wynik = odwiedzajacy.Select((o, i) => (o, zmarli[i]));

            return wynik;
        }
        */
    }
}
