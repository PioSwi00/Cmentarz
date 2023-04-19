using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    public class ZmarliController : Controller
    {
        private readonly IZmarlyService _zmarlyService;

        public ZmarliController(IZmarlyService zmarlyService)
        {
            _zmarlyService = zmarlyService;
        }

        public IActionResult Index()
        {
            var zmarli = _zmarlyService.PobierzZmarlychZPrzedzialuCzasu(DateTime.Now.AddDays(-30), DateTime.Now);
            return View(zmarli);
        }
    }
}
