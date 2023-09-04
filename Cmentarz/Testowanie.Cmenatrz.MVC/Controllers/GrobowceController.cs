using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Testowanie.Cmenatrz.MVC.Models;

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
        public IActionResult DodajZmarlego(int idGrobowca)
        {
            var grobowiec = _grobowiecService.GetGrobowceFilteredById(idGrobowca);

            if (grobowiec == null)
            {
                ViewBag.ErrorMessage = "Nie znaleziono grobowca o podanym ID.";
                return View("Error");
            }

            var zmarlyViewModel = new ZmarlyViewModel
            {
                GrobowiecID = idGrobowca
            };

            return View(zmarlyViewModel);
        }
        [HttpPost]
        public IActionResult DodajZmarlego(ZmarlyViewModel zmarlyViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(zmarlyViewModel);
                }

                // Tworzenie obiektu Zmarly na podstawie danych z zmarlyViewModel
                var zmarly = new Zmarly
                {
                    // Przypisz właściwości zmarłego na podstawie zmarlyViewModel
                    GrobowiecID = zmarlyViewModel.GrobowiecID,
                    // Ustaw pozostałe właściwości związane z zmarłym, np. Imie, Nazwisko itp.
                };

                _grobowiecService.DodajZmarlegoDoGrobowca(zmarly.GrobowiecID,zmarly);

                // Możesz dodać informację o sukcesie do ViewBag, jeśli chcesz
                ViewBag.SuccessMessage = "Zmarły został dodany do grobowca.";

                // Pozostań na bieżącej stronie
                return View(zmarlyViewModel);
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
