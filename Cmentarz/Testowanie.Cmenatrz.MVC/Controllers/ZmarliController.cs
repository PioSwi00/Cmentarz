using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Testowanie.Cmentarz.MVC.Models;

namespace Testowanie.Cmentarz.MVC.Controllers
{
    public class ZmarliController : Controller
    {
        private readonly IZmarlyService _zmarlyService;

        public ZmarliController(IZmarlyService zmarlyService)
        {
            _zmarlyService = zmarlyService;
        }

        [HttpGet]
        public IActionResult ZakresDat()
        {
            var viewModel = new ZakresDatViewModel()
            {
                DataOd = DateTime.Now.AddDays(-30),
                DataDo = DateTime.Now
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Index(ZakresDatViewModel viewModel)
        {
            var zmarli = _zmarlyService.PobierzZmarlychZPrzedzialuCzasu(viewModel.DataOd, viewModel.DataDo);
            return View(zmarli);
        }
    }
}
