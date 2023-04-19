using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Testowanie.Cmenatrz.MVC.Models;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    public class GrobowiecController : Controller
    {
        private readonly IGrobowiecService _grobowiecService;

        public GrobowiecController(IGrobowiecService grobowiecService)
        {
            _grobowiecService = grobowiecService;
        }

        public IActionResult Index()
        {
            var grobowce = _grobowiecService.PobierzWszystkieGrobowce();
            return View(grobowce);
        }

        [HttpGet]
        public IActionResult WyszukajGroby()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WyszukajGroby(int idGrobu, int idWlasciciel, string lokalizacja, decimal cena)
        {
            var wynikiWyszukiwania = _grobowiecService.WyszukajGroby(idGrobu, idWlasciciel, lokalizacja, cena);
            return View(wynikiWyszukiwania);
        }
    }


}
