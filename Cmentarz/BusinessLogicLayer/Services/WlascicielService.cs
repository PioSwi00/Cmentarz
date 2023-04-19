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

    }
}
