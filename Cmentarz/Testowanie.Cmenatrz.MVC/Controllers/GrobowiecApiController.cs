using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrobowiecApiController : ControllerBase
    {
        private readonly IGrobowiecService _grobowiecService;

        public GrobowiecApiController(IGrobowiecService grobowiecService)
        {
            _grobowiecService = grobowiecService;
        }



        [HttpGet("GrobowceFilteredById/{id}")]
        public IActionResult GetGrobowceFilteredById(int id)
        {
            var grobowiec = _grobowiecService.GetGrobowceFilteredById(id);
            if (grobowiec == null)
            {
                return NotFound();
            }
            return Ok(grobowiec);
        }

        [HttpGet]
        public IActionResult GetAllGrobowce()
        {
            var grobowce = _grobowiecService.PobierzWszystkieGrobowce();
            return Ok(grobowce);
        }

        [HttpPost("DodajZmarlegoDoGrobowca/{idGrobowca}")]
        public IActionResult DodajZmarlegoDoGrobowca(int idGrobowca, [FromBody] Zmarly zmarly)
        {
            try
            {
                _grobowiecService.DodajZmarlegoDoGrobowca(idGrobowca, zmarly);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("WyszukajGroby")]
        public IActionResult WyszukajGroby([FromQuery] int idGrobu, [FromQuery] int idWlasciciel, [FromQuery] string lokalizacja, [FromQuery] decimal cena)
        {
            var grobowce = _grobowiecService.WyszukajGroby(idGrobu, idWlasciciel, lokalizacja, cena);
            return Ok(grobowce);
        }

        [HttpGet("IloscOdwiedzajacych/{idGrobowca}")]
        public IActionResult IloscOdwiedzajacych(int idGrobowca)
        {
            var iloscOdwiedzajacych = _grobowiecService.IloscOdwiedzajacych(idGrobowca);
            return Ok(iloscOdwiedzajacych);
        }

    }
}
