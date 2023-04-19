using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cmentarz.WEB.Controllers
{
    public class OdwiedzajacyController : Controller
    {
        private IUnitOfWork _context;


        public OdwiedzajacyController(DbCmentarzContext context)
        {
            this._context = new UoW(context);
        }

        // GET: Odwiedzajacy
        public async Task<IActionResult> Index()
        {
            var Odwiedzajacy = _context.Odwiedzajacy.GetAll(); // pobierz wszystkie Odwiedzajacy za pomocą metody GetAllAsync() z klasy OdwiedzajacyRepository
            if (Odwiedzajacy == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Odwiedzajacy' is null.");
            }
            return View(Odwiedzajacy);
        }

        // GET: Odwiedzajacy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Odwiedzajacy == null)
            {
                return NotFound();
            }

            var Odwiedzajacy = _context.Odwiedzajacy.GetById((int)id);
            if (Odwiedzajacy == null)
            {
                return NotFound();
            }

            return View(Odwiedzajacy);
        }

        // GET: Odwiedzajacy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odwiedzajacy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOdwiedzajacy,Imie,Nazwisko")] Odwiedzajacy odwiedzajacy)
        {
            if (ModelState.IsValid)
            {
                _context.Odwiedzajacy.Add(odwiedzajacy);
                _context.Odwiedzajacy.SaveChanges(odwiedzajacy);
                return RedirectToAction(nameof(Index));
            }
            return View(odwiedzajacy);
        }

        // GET: Odwiedzajacy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Odwiedzajacy == null)
            {
                return NotFound();
            }

            var Odwiedzajacy =  _context.Odwiedzajacy.GetById((int)id);
            if (Odwiedzajacy == null)
            {
                return NotFound();
            }

            return View(Odwiedzajacy);
        }

        // POST: Odwiedzajacy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOdwiedzajacy,IdWlasciciel,Lokalizacja,Cena")] Odwiedzajacy odwiedzajacy)
        {
            if (id != odwiedzajacy.IdOdwiedzajacy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _context.Odwiedzajacy.Update(odwiedzajacy);
                    _context.Odwiedzajacy.SaveChanges(odwiedzajacy);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdwiedzajacyExists(odwiedzajacy.IdOdwiedzajacy))
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
            return View(odwiedzajacy);
        }

        // GET: Odwiedzajacy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Odwiedzajacy == null)
            {
                return NotFound();
            }

            var Odwiedzajacy =  _context.Odwiedzajacy
                .FirstOrDefault(m => m.IdOdwiedzajacy == id);
            if (Odwiedzajacy == null)
            {
                return NotFound();
            }

            return View(Odwiedzajacy);
        }

        // POST: Odwiedzajacy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Odwiedzajacy == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Odwiedzajacy'  is null.");
            }
            var Odwiedzajacy =  _context.Odwiedzajacy.GetById(id);
            if (Odwiedzajacy != null)
            {
                _context.Odwiedzajacy.Delete(Odwiedzajacy);
            }

            _context.Odwiedzajacy.SaveChanges(Odwiedzajacy);
            return RedirectToAction(nameof(Index));
        }

        private bool OdwiedzajacyExists(int id)
        {
            return true;// (_context.Odwiedzajacy?.Any(e => e.IdOdwiedzajacy == id)).GetValueOrDefault();
        }
    }
}
