using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WlascicielApiController : ControllerBase
    {
        private readonly IWlascicielService _wlascicielService;

        public WlascicielApiController(IWlascicielService wlascicielService)
        {
            _wlascicielService = wlascicielService;
        }

        [HttpGet]
        public IActionResult GetWlasciciele()
        {
            var wlasciciele = _wlascicielService.GetWlasciciele();
            return Ok(wlasciciele);
        }

        [HttpGet]
        [Route("GetByNazwisko/{nazwisko}")]
        public IActionResult GetWlascicieleByNazwisko(string nazwisko)
        {
            var wlasciciele = _wlascicielService.GetByNazwisko(nazwisko);
            if (wlasciciele == null || !wlasciciele.Any())
            {
                return NotFound();
            }

            var response = new
            {
                Status = "OK",
                Wlasciciele = wlasciciele
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("WlascicielGetByOrder")]
        public IActionResult WlascicielGetByOrder(string sortBy)
        {
            var wlasciciele = _wlascicielService.WlascicielGetByOrder(sortBy);
            return Ok(wlasciciele);
        }
    }
}
