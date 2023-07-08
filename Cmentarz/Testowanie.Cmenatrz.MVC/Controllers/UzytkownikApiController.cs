using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testowanie.Cmenatrz.MVC.Models;

namespace Testowanie.Cmenatrz.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UzytkownikApiController : ControllerBase
    {
        private readonly IUzytkownikService _uzytkownikService;

        public UzytkownikApiController(IUzytkownikService uzytkownikService)
        {
            _uzytkownikService = uzytkownikService;
        }

        [HttpGet("KupowanieGrobowca")]
        public IActionResult KupowanieGrobowca(int idUzytkownik, int idGrobowiec)
        {
            var viewModel = new KupowanieGrobowcaViewModel
            {
                IdUzytkownik = idUzytkownik,
                IdGrobowiec = idGrobowiec
            };

            var result = _uzytkownikService.KupGrobowiec(viewModel.IdUzytkownik, viewModel.IdGrobowiec);           
            return Ok(result);
        }

        [HttpPost("KupowanieGrobowca")]
        public IActionResult KupowanieGrobowca(KupowanieGrobowcaViewModel viewModel)
        {
           
            var result = _uzytkownikService.KupGrobowiec(viewModel.IdUzytkownik, viewModel.IdGrobowiec);
            return Ok(result);
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _uzytkownikService.Login(viewModel.Login, viewModel.Haslo);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Nieprawidłowy login lub hasło.");
                return BadRequest(ModelState);
            }

            var response = new
            {
                UserName = user.Login
            };

            return Ok(response);
        }


        [HttpGet("Witaj")]
        public IActionResult Witaj()
        {
            return Ok("Witaj");
        }
        [HttpGet("Uzytkownicy")]
        public IActionResult Uzytkownicy()
        {
            var uzytkownicy = _uzytkownikService.PobierzWszystkichUzytkownikow();
            return Ok(uzytkownicy);
        }

        [HttpPost("DodajUzytkownika")]
        public IActionResult DodajUzytkownika([FromBody] Uzytkownik uzytkownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _uzytkownikService.DodajUzytkownika(uzytkownik);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
