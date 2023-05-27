using BusinessLogicLayer.Interfaces;
<<<<<<< Updated upstream
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testowanie.Cmentarz.MVC.Models;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZmarliApiController : ControllerBase
    {
        private readonly IZmarlyService _zmarlyService;
        
        public ZmarliApiController(IZmarlyService zmarlyService)
        {
            
            _zmarlyService = zmarlyService;
        }

        [HttpGet("ZakresDat")]
        public IActionResult ZakresDat()
        {
            var viewModel = new ZakresDatViewModel()
            {
                DataOd = DateTime.Now.AddDays(-30),
                DataDo = DateTime.Now
            };
            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult Index([FromQuery] ZakresDatViewModel viewModel)
        {
            var zmarli = _zmarlyService.PobierzZmarlychZPrzedzialuCzasu(viewModel.DataOd, viewModel.DataDo);
            return Ok(zmarli);
        }
    }
}
=======
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
>>>>>>> Stashed changes
