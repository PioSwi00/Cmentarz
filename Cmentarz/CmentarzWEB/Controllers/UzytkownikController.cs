using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cmentarz.WEB.Controllers
{
    public class UzytkownikController : Controller
    {
        private IUnitOfWork _context;


        public UzytkownikController(DbCmentarzContext context)
        {
            this._context = new UoW(context);
        }

        // GET: Uzytkownik
        public async Task<IActionResult> Index()
        {
            var Uzytkownicy = await _context.Uzytkownicy.GetAll(); // pobierz wszystkie Uzytkownicy za pomocą metody GetAllAsync() z klasy UzytkownikRepository
            if (Uzytkownicy == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Uzytkownicy' is null.");
            }
            return View(Uzytkownicy);
        }

        // GET: Uzytkownik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uzytkownicy == null)
            {
                return NotFound();
            }

            var Uzytkownik = await _context.Uzytkownicy.GetById((int)id);
            if (Uzytkownik == null)
            {
                return NotFound();
            }

            return View(Uzytkownik);
        }

        // GET: Uzytkownik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUzytkownik,IdWlasciciel,Lokalizacja,Cena")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                await _context.Uzytkownicy.Add(uzytkownik);
                await _context.Uzytkownicy.SaveChanges(uzytkownik);
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uzytkownicy == null)
            {
                return NotFound();
            }

            var Uzytkownik = await _context.Uzytkownicy.GetById((int)id);
            if (Uzytkownik == null)
            {
                return NotFound();
            }

            return View(Uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUzytkownik,IdWlasciciel,Lokalizacja,Cena")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.IdUzytkownik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Uzytkownicy.Update(uzytkownik);
                    await _context.Uzytkownicy.SaveChanges(uzytkownik);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownikExists(uzytkownik.IdUzytkownik))
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
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uzytkownicy == null)
            {
                return NotFound();
            }

            var Uzytkownik = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.IdUzytkownik == id);
            if (Uzytkownik == null)
            {
                return NotFound();
            }

            return View(Uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uzytkownicy == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Uzytkownicy'  is null.");
            }
            var Uzytkownik = await _context.Uzytkownicy.GetById(id);
            if (Uzytkownik != null)
            {
                await _context.Uzytkownicy.Delete(Uzytkownik);
            }

            await _context.Uzytkownicy.SaveChanges(Uzytkownik);
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
        {
            return true;// (_context.Uzytkownicy?.Any(e => e.IdUzytkownik == id)).GetValueOrDefault();
        }
    }
}
