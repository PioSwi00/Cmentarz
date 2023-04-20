using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var odwiedzajacy = _odwiedzajacyService.WyszukajOdwiedzajacych(idOdwiedzajacy, imie, nazwisko);

            if (odwiedzajacy.Any())
            {
                return View(odwiedzajacy);
            }
            else
            {
                TempData["message"] = "Nie znaleziono odwiedzającego.";
                return View();
            }
        }
    }
}
