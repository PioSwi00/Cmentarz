using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Testowanie.Cmenatrz.MVC.Models;
namespace Testowanie.Cmenatrz.MVC.Controllers
{
    public class WlascicielController : Controller
    {
        private readonly IWlascicielService _wlascicielService;

        public WlascicielController(IWlascicielService wlascicielService)
        {
            _wlascicielService = wlascicielService;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NazwiskoSortParm"] = sortOrder == "Nazwisko" ? "nazwisko_desc" : "Nazwisko";
            ViewData["IDSortParm"] = sortOrder == "ID" ? "id_desc" : "ID";

            var wlasciciele = _wlascicielService.WlascicielGetByOrder(sortOrder);

            switch (sortOrder)
            {
                case "name_desc":
                    wlasciciele = wlasciciele.OrderByDescending(w => w.Imie);
                    break;
                case "Nazwisko":
                    wlasciciele = wlasciciele.OrderBy(w => w.Nazwisko);
                    break;
                case "nazwisko_desc":
                    wlasciciele = wlasciciele.OrderByDescending(w => w.Nazwisko);
                    break;
                case "ID":
                    wlasciciele = wlasciciele.OrderBy(w => w.IdWlasciciel);
                    break;
                case "id_desc":
                    wlasciciele = wlasciciele.OrderByDescending(w => w.IdWlasciciel);
                    break;
                default:
                    wlasciciele = wlasciciele.OrderBy(w => w.Imie);
                    break;
            }

            var model = new Wlasciciel
            {
                Wlasciciele = wlasciciele.ToList(),
                CurrentSort = sortOrder
            };

            return View(model);
        }
    }
}
