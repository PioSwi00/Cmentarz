using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Testowanie.Cmenatrz.MVC.Models;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    public class UzytkownikController : Controller
    {
        private readonly IUzytkownikService _uzytkownikService;

        public UzytkownikController(IUzytkownikService uzytkownikService)
        {
            _uzytkownikService = uzytkownikService;
        }

        [HttpGet]
        public IActionResult KupowanieGrobowca(int idUzytkownik, int idGrobowiec)
        {
            var viewModel = new KupowanieGrobowcaViewModel
            {
                IdUzytkownik = idUzytkownik,
                IdGrobowiec = idGrobowiec
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Index(KupowanieGrobowcaViewModel viewModel)
        {
            var kupionyGrob = _uzytkownikService.KupGrobowiec(viewModel.IdUzytkownik, viewModel.IdGrobowiec);
            return View(kupionyGrob);
        }

        [HttpGet]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _uzytkownikService.Login(viewModel.Login, viewModel.Haslo);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Nieprawidłowy login lub hasło.");
                return View(viewModel);
            }

            return RedirectToAction(nameof(Witaj));
        }

        public IActionResult Witaj()
        {
            return View();
        }
    }
}
