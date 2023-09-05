using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testowanie.Cmenatrz.MVC.Models;
using Newtonsoft.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPut("KupowanieGrobowca"), Authorize]
        public IActionResult KupowanieGrobowca(int idUzytkownik, int idGrobowiec)
        {
            if (idUzytkownik <= 0 || idGrobowiec <= 0)
            {
                return BadRequest("Nieprawidłowe identyfikatory.");
            }

            try
            {
                var viewModel = new KupowanieGrobowcaViewModel
                {
                    IdUzytkownik = idUzytkownik,
                    IdGrobowiec = idGrobowiec
                };

                var result = _uzytkownikService.KupGrobowiec(viewModel.IdUzytkownik, viewModel.IdGrobowiec);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*

        [HttpPut("KupowanieGrobowca"), Authorize]
        public IActionResult KupowanieGrobowca(KupowanieGrobowcaViewModel viewModel)
        {
           
            var result = _uzytkownikService.KupGrobowiec(viewModel.IdUzytkownik, viewModel.IdGrobowiec);
            return Ok(result);
        }
        */
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
            string token = GenerateToken(user.IdUzytkownik); // Generuj token dla zalogowanego użytkownika
            var response = new
            {
                UserName = user.Login,
                Token = token
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
        [HttpDelete("UsunUzytkownika"), Authorize]
        public IActionResult UsunUzytkownika()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                try
                {
                    _uzytkownikService.UsunUzytkownika(userId);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Nie można zidentyfikować użytkownika.");
            }
        }

        [HttpPut("ZmienHaslo/{id}"), Authorize]
        public IActionResult ZmienHaslo([FromBody]string noweHaslo)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                try
                {
                    _uzytkownikService.ZmienHaslo(userId, noweHaslo);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Nie można zidentyfikować użytkownika.");
            }
        }

        [HttpGet("GetUserIdFromToken"), Authorize]
        public IActionResult GetUserIdFromToken()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return Ok(userId);
            }
            else
            {
                return NotFound(); // Token nie zawiera identyfikatora użytkownika lub jest nieprawidłowy
            }
        }

        private string GenerateToken(int userId)
        {
            var key = Encoding.ASCII.GetBytes("SuperSekretnyKlucz123");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Audience = "UzytkownikApi",
                Issuer = "UzytkownikApi",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
 