using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cmentarz.WEB.Controllers
{
    public class WlascicielController : Controller
    {
        private IUnitOfWork _context;


        public WlascicielController(DbCmentarzContext context)
        {
            this._context = new UoW(context);
        }

        // GET: Wlasciciel
        public async Task<IActionResult> Index()
        {
            var Wlasciciele = _context.Wlasciciele.GetAll(); // pobierz wszystkie Wlasciciele za pomocą metody GetAllAsync() z klasy WlascicielRepository
            if (Wlasciciele == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Wlasciciele' is null.");
            }
            return View(Wlasciciele);
        }

        // GET: Wlasciciel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wlasciciele == null)
            {
                return NotFound();
            }

            var Wlasciciel = _context.Wlasciciele.GetById((int)id);
            if (Wlasciciel == null)
            {
                return NotFound();
            }

            return View(Wlasciciel);
        }

        // GET: Wlasciciel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wlasciciel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWlasciciel,Imie,Nazwisko,Adres,IlGrobowcow")] Wlasciciel wlasciciel)
        {
            if (ModelState.IsValid)
            {
                _context.Wlasciciele.Add(wlasciciel);
                _context.Wlasciciele.SaveChanges(wlasciciel);
                return RedirectToAction(nameof(Index));
            }
            return View(wlasciciel);
        }

        // GET: Wlasciciel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wlasciciele == null)
            {
                return NotFound();
            }

            var Wlasciciel = _context.Wlasciciele.GetById((int)id);
            if (Wlasciciel == null)
            {
                return NotFound();
            }

            return View(Wlasciciel);
        }

        // POST: Wlasciciel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWlasciciel,IdWlasciciel,Lokalizacja,Cena")] Wlasciciel wlasciciel)
        {
            if (id != wlasciciel.IdWlasciciel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Wlasciciele.Update(wlasciciel);
                    _context.Wlasciciele.SaveChanges(wlasciciel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WlascicielExists(wlasciciel.IdWlasciciel))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wlasciciel);
        }

        // GET: Wlasciciel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wlasciciele == null)
            {
                return NotFound();
            }

            var Wlasciciel = _context.Wlasciciele
                .FirstOrDefault(m => m.IdWlasciciel == id);
            if (Wlasciciel == null)
            {
                return NotFound();
            }

            return View(Wlasciciel);
        }

        // POST: Wlasciciel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wlasciciele == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Wlasciciele'  is null.");
            }
            var Wlasciciel = _context.Wlasciciele.GetById(id);
            if (Wlasciciel != null)
            {
                _context.Wlasciciele.Delete(Wlasciciel);
            }

            _context.Wlasciciele.SaveChanges(Wlasciciel);
            return RedirectToAction(nameof(Index));
        }

        private bool WlascicielExists(int id)
        {
            return true;// (_context.Wlasciciele?.Any(e => e.IdWlasciciel == id)).GetValueOrDefault();
        }
    }
}
