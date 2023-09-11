﻿using BusinessLogicLayer.Interfaces;
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
        public IActionResult WyszukajGroby([FromQuery] int? idGrobu, [FromQuery] int? idWlasciciel, [FromQuery] string? lokalizacja, [FromQuery] decimal? cena, [FromQuery]String? sektor)
        {
            if (!idGrobu.HasValue && !idWlasciciel.HasValue && string.IsNullOrEmpty(lokalizacja) && !cena.HasValue)
            {
                return GetAllGrobowce();
            }

            var grobowce = _grobowiecService.WyszukajGroby(idGrobu, idWlasciciel, lokalizacja, cena,sektor);
            return Ok(grobowce);
        }


        [HttpGet("IloscOdwiedzajacych/{idGrobowca}")]
        public IActionResult IloscOdwiedzajacych(int idGrobowca)
        {
            var iloscOdwiedzajacych = _grobowiecService.IloscOdwiedzajacych(idGrobowca);
            return Ok(iloscOdwiedzajacych);
        }

        [HttpGet("PobierzWolneGroby")]
        public IActionResult PobierzWolneGroby()
        {
            var wolneGroby = _grobowiecService.PobierzWolneGroby();
            return Ok(wolneGroby);
        }

        [HttpGet("PobierzGrobowceWlasciciela/{idWlasciciela}")]
        public IActionResult PobierzGrobowceWlasciciela(int idWlasciciela)
        {
            var grobyWlasciciela = _grobowiecService.PobierzGrobyWlasciciela(idWlasciciela);
            return Ok(grobyWlasciciela);
        }
        [HttpPost("DodajOdwiedzajacegoDoGrobowca/{idGrobowca}/{idOdwiedzajacego}")]
        public IActionResult DodajOdwiedzajacegoDoGrobowca(int idGrobowca, int idOdwiedzajacego)
        {
            try
            {
                _grobowiecService.DodajOdwiedzajacegoDoGrobowca(idGrobowca, idOdwiedzajacego);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UsunOdwiedzajacegoZGrobowca/{idGrobowca}/{idOdwiedzajacego}")]
        public IActionResult UsunOdwiedzajacegoZGrobowca(int idGrobowca, int idOdwiedzajacego)
        {
            _grobowiecService.UsunOdwiedzajacegoZGrobowca(idGrobowca, idOdwiedzajacego);
            return Ok();
        }

    }
}
