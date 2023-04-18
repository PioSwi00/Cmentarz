using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cmentarz.WEB.Controllers
{
    public class ZmarlyController : Controller
    {
        private IUnitOfWork _context;


        public ZmarlyController(DbCmentarzContext context)
        {
            this._context = new UoW(context);
        }

        // GET: Zmarly
        public async Task<IActionResult> Index()
        {
            var Zmarli = await _context.Zmarli.GetAll(); // pobierz wszystkie Zmarli za pomocą metody GetAllAsync() z klasy ZmarlyRepository
            if (Zmarli == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Zmarli' is null.");
            }
            return View(Zmarli);
        }

        // GET: Zmarly/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zmarli == null)
            {
                return NotFound();
            }

            var Zmarly = await _context.Zmarli.GetById((int)id);
            if (Zmarly == null)
            {
                return NotFound();
            }

            return View(Zmarly);
        }

        // GET: Zmarly/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zmarly/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZmarly,Imie,Nazwisko,DataUrodzenia,DataSmierci")] Zmarly zmarly)
        {
            if (ModelState.IsValid)
            {
                await _context.Zmarli.Add(zmarly);
                await _context.Zmarli.SaveChanges(zmarly);
                return RedirectToAction(nameof(Index));
            }
            return View(zmarly);
        }

        // GET: Zmarly/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zmarli == null)
            {
                return NotFound();
            }

            var Zmarly = await _context.Zmarli.GetById((int)id);
            if (Zmarly == null)
            {
                return NotFound();
            }

            return View(Zmarly);
        }

        // POST: Zmarly/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZmarly,IdWlasciciel,Lokalizacja,Cena")] Zmarly zmarly)
        {
            if (id != zmarly.IdZmarly)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Zmarli.Update(zmarly);
                    await _context.Zmarli.SaveChanges(zmarly);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZmarlyExists(zmarly.IdZmarly))
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
            return View(zmarly);
        }

        // GET: Zmarly/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zmarli == null)
            {
                return NotFound();
            }

            var Zmarly = await _context.Zmarli
                .FirstOrDefaultAsync(m => m.IdZmarly == id);
            if (Zmarly == null)
            {
                return NotFound();
            }

            return View(Zmarly);
        }

        // POST: Zmarly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zmarli == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Zmarli'  is null.");
            }
            var Zmarly = await _context.Zmarli.GetById(id);
            if (Zmarly != null)
            {
                await _context.Zmarli.Delete(Zmarly);
            }

            await _context.Zmarli.SaveChanges(Zmarly);
            return RedirectToAction(nameof(Index));
        }

        private bool ZmarlyExists(int id)
        {
            return true;// (_context.Zmarli?.Any(e => e.IdZmarly == id)).GetValueOrDefault();
        }
    }
}
