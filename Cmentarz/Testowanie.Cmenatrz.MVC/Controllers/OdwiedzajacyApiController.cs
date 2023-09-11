using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Testowanie.Cmenatrz.MVC.Models;

namespace Testowanie.Cmentarz.MVC.Controllers
{
    public class OdwiedzajacyApiController : ControllerBase
    {
        private readonly IOdwiedzajacyService _odwiedzajacyService;

        public OdwiedzajacyApiController(IOdwiedzajacyService odwiedzajacyService)
        {
            _odwiedzajacyService = odwiedzajacyService;
        }

        [HttpGet]
        [Route("WyszukajOdwiedzajacych")]
        public IActionResult WyszukajOdwiedzajacych()
        {
            return Ok();
        }


        [HttpGet]
        [Route("WyszukajOdwiedzajacych/ByQuery")]
        public IActionResult WyszukajOdwiedzajacychByQuery([FromQuery] int idOdwiedzajacy, [FromQuery] string imie, [FromQuery] string nazwisko)
        {
            var odwiedzajacy = _odwiedzajacyService.WyszukajOdwiedzajacych(idOdwiedzajacy, imie, nazwisko);

            if (odwiedzajacy.Any())
            {
                var result = odwiedzajacy.Select(o => new
                {
                    Id = o.IdOdwiedzajacy,
                    Imie = o.Imie,
                    Nazwisko = o.Nazwisko
                });

                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet]
        [Route("api/WyszukajOdwiedzajacych")]
        public IActionResult WyszukajOdwiedzajacych([FromBody] WyszukajOdwiedzajacychRequest request)
        {
            var odwiedzajacy = _odwiedzajacyService.WyszukajOdwiedzajacych(request.IdOdwiedzajacy, request.Imie, request.Nazwisko).ToList();

            if (odwiedzajacy.Count() > 0)
            {
                var response = new WyszukajOdwiedzajacychResponse(request.IdOdwiedzajacy, request.Imie, request.Nazwisko, odwiedzajacy);

                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
