using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Testowanie.Cmentarz.MVC.Controllers
{
    public class GrobowiecController : Controller
    {
        private readonly IGrobowiecService _grobowiecService;

        public GrobowiecController(IGrobowiecService grobowiecService)
        {
            _grobowiecService = grobowiecService;
        }

        public IActionResult WyszukajGroby(int? idGrobu, int? idWlasciciel, string lokalizacja, decimal? cena)
        {
            if (!idGrobu.HasValue && !idWlasciciel.HasValue && string.IsNullOrEmpty(lokalizacja) && !cena.HasValue)
            {
                var wszystkieGroby = _grobowiecService.PobierzWszystkieGrobowce();
                return View(wszystkieGroby);
            }

            var grobowce = _grobowiecService.WyszukajGroby(idGrobu, idWlasciciel, lokalizacja, cena);
            return View(grobowce);
        }

        public IActionResult IloscOdwiedzajacych(int idGrobowca)
        {
            var iloscOdwiedzajacych = _grobowiecService.IloscOdwiedzajacych(idGrobowca);
            return View(iloscOdwiedzajacych);
        }

        public IActionResult PobierzWolneGroby()
        {
            var wolneGroby = _grobowiecService.PobierzWolneGroby();
            return View(wolneGroby);
        }
    }
}
