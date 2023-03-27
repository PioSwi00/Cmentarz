using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Cmentarz.DAL.Repositories;
namespace Cmentarz.WEB.Controllers
{
    public class GrobowiecController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GrobowiecController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var grobowce = _unitOfWork.Grobowce.GetAll();
            return View(grobowce);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var grobowiec =  _unitOfWork.Grobowce.GetAll();
            if (grobowiec == null)
            {
                return NotFound();
            }
            return View(grobowiec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,DataUtworzenia,LiczbaMiejsc,IdWlasciciela")] Grobowiec grobowiec)
        {
            if (id != grobowiec.IdGrobowiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Grobowce.Update(grobowiec);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(grobowiec);
        }

    }

}
