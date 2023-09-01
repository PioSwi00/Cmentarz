using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Testowanie.Cmenatrz.MVC.Models;
using Testowanie.Cmentarz.MVC.Models;

namespace Testowanie.Cmentarz.MVC.Controllers
{
    public class OdwiedzajacyController : Controller
    {
        private readonly IOdwiedzajacyService _odwiedzajacyService;

        public OdwiedzajacyController(IOdwiedzajacyService odwiedzajacyService)
        {
            _odwiedzajacyService = odwiedzajacyService;
        }

        public IActionResult WyszukajOdwiedzajacych()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WyszukajOdwiedzajacych(int idOdwiedzajacy, string imie, string nazwisko)
        {
            if (_odwiedzajacyService != null)
            {
                var odwiedzajacy = _odwiedzajacyService.WyszukajOdwiedzajacych(idOdwiedzajacy, imie, nazwisko);

                if (odwiedzajacy.Any())
                {
                    return View("WyszukajOdwiedzajacych", odwiedzajacy);
                }
            }

            TempData["message"] = "Nie znaleziono odwiedzającego.";
            return View("WyszukajOdwiedzajacych");
        }

        public IActionResult WyszukajOdwiedzajacychByQuery(int idOdwiedzajacy, string imie, string nazwisko)
        {
            var odwiedzajacy = _odwiedzajacyService.WyszukajOdwiedzajacych(idOdwiedzajacy, imie, nazwisko);

            if (odwiedzajacy.Any())
            {
                return View("WyszukajOdwiedzajacych", odwiedzajacy);
            }

            TempData["message"] = "Nie znaleziono odwiedzającego.";
            return View("WyszukajOdwiedzajacych");
        }

        public IActionResult WyszukajOdwiedzajacychByQuery([FromBody] WyszukajOdwiedzajacychRequest request)
        {
            var odwiedzajacy = _odwiedzajacyService.WyszukajOdwiedzajacych(request.IdOdwiedzajacy, request.Imie, request.Nazwisko);

            if (odwiedzajacy.Any())
            {
                return View("WyszukajOdwiedzajacych", odwiedzajacy);
            }

            TempData["message"] = "Nie znaleziono odwiedzającego.";
            return View("WyszukajOdwiedzajacych");
        }
    }
}
