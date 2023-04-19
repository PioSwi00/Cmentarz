using BusinessLogicLayer.Interfaces;
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

        public ActionResult Index()
        {
            var grobowce = _grobowiecService.PobierzWszystkieGrobowce();
            return View(grobowce);
        }

        // pozostałe akcje kontrolera
    }

}
