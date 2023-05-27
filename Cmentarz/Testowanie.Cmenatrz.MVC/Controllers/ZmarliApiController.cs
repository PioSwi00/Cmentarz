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
