using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Testowanie.Cmentarz.MVC.Controllers
{
    public class GrobowceController : Controller
    {
        private readonly IGrobowiecService _grobowiecService;

        public GrobowceController(IGrobowiecService grobowiecService)
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

        [HttpGet]
        public IActionResult IloscOdwiedzajacych()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IloscOdwiedzajacych(int idGrobowca)
        {
            try
            {
                var iloscOdwiedzajacych = _grobowiecService.IloscOdwiedzajacych(idGrobowca);
                ViewBag.IdGrobowca = idGrobowca; // Przekazujemy ID do widoku
                return View("WyswietlIloscOdwiedzajacych", iloscOdwiedzajacych);
            }
            catch (ArgumentException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }


        public IActionResult PobierzWolneGroby()
        {
            var wolneGroby = _grobowiecService.PobierzWolneGroby();
            return View(wolneGroby);
        }

        [HttpGet]
        public IActionResult DodajZmarlegoDoGrobowca(int idGrobowca)
        {
            try
            {
                var grobowiec = _grobowiecService.GetGrobowceFilteredById(idGrobowca);

                if (grobowiec == null)
                {
                    ViewBag.ErrorMessage = "Nie znaleziono grobowca o podanym ID.";
                    return View("Error");
                }

                var zmarly = new Zmarly();
                zmarly.GrobowiecID = idGrobowca; 
                return View(zmarly);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Wystąpił błąd podczas przetwarzania żądania: " + ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DodajZmarlegoDoGrobowca(Zmarly zmarly)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(zmarly);
                }

                _grobowiecService.DodajZmarlegoDoGrobowca(zmarly.IdZmarly, zmarly);
                return RedirectToAction("SzczegolyGrobu", new { id = zmarly.GrobowiecID });
            }
            catch (ArgumentException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Wystąpił błąd podczas przetwarzania żądania: " + ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult DodajGrobowiec()
        {
            var nowyGrobowiec = new Grobowiec(); // Tworzymy nowy obiekt Grobowiec
            return View(nowyGrobowiec); // Zwracamy widok z formularzem do dodawania grobowca
        }

        [HttpPost]
        public IActionResult DodajGrobowiec(Grobowiec grobowiec)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _grobowiecService.DodajGrobowiec(grobowiec);
                    return RedirectToAction("WyszukajGroby");
                }
                return View(grobowiec);
            }
            catch (Exception ex)
            {
               
                ViewBag.ErrorMessage = "Wystąpił błąd podczas przetwarzania żądania: " + ex.Message;
                return View("Error");
            }
        }

    }
}
