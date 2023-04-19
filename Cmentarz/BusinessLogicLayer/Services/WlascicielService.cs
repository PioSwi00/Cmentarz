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

        
    }
}
