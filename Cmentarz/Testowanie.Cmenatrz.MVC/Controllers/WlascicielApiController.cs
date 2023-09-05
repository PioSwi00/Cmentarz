using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Cmentarz.DAL.Models;
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
        public IActionResult GetWlascicieleById()
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

        [HttpPost("DodajWlasciciela")]
        public IActionResult DodajWlasciciela([FromBody]Wlasciciel wlasciciel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _wlascicielService.DodajWlasciciela(wlasciciel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("WlascicielGetByOrder")]
        public IActionResult WlascicielGetByOrder(string sortBy)
        {
            var wlasciciele = _wlascicielService.WlascicielGetByOrder(sortBy);
            return Ok(wlasciciele);
        }

        [HttpGet("GetWlascicielById/{idWlasciciela}")]
        public IActionResult GetWlascicielById(int idWlasciciela)
        {
            var wlasciciel = _wlascicielService.GetWlascicielById(idWlasciciela);
            return Ok(wlasciciel);
        }

    }
}
