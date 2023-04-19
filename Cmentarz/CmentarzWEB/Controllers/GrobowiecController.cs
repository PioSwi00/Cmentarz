using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;

namespace Cmentarz.WEB.Controllers
{
    public class GrobowiecController : Controller
    {
        private IUnitOfWork _context;
       

        public GrobowiecController(DbCmentarzContext context)
        {
            this._context = new UoW(context);
        }

        // GET: Grobowiec
        public async Task<IActionResult> Index()
        {
            var grobowce =  _context.Grobowce.GetAll(); // pobierz wszystkie grobowce za pomocą metody GetAllAsync() z klasy GrobowiecRepository
            if (grobowce == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Grobowce' is null.");
            }
            return View(grobowce);
        }

        // GET: Grobowiec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grobowce == null)
            {
                return NotFound();
            }

            var grobowiec =  _context.Grobowce.GetById((int)id);
            if (grobowiec == null)
            {
                return NotFound();
            }

            return View(grobowiec);
        }

        // GET: Grobowiec/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grobowiec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrobowiec,IdWlasciciel,Lokalizacja,Cena,CzyZajete")] Grobowiec grobowiec)
        {
            if (ModelState.IsValid)
            {
                _context.Grobowce.Add(grobowiec);
                 _context.Grobowce.SaveChanges(grobowiec);
                return RedirectToAction(nameof(Index));
            }
            return View(grobowiec);
        }

        // GET: Grobowiec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grobowce == null)
            {
                return NotFound();
            }

            var grobowiec =  _context.Grobowce.GetById((int)id);
            if (grobowiec == null)
            {
                return NotFound();
            }

            return View(grobowiec);
        }

        // POST: Grobowiec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrobowiec,IdWlasciciel,Lokalizacja,Cena")] Grobowiec grobowiec)
        {
            if (id != grobowiec.IdGrobowiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Grobowce.Update(grobowiec);
                     _context.Grobowce.SaveChanges(grobowiec);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrobowiecExists(grobowiec.IdGrobowiec))
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
            return View(grobowiec);
        }

        // GET: Grobowiec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grobowce == null)
            {
                return NotFound();
            }

            var grobowiec =  _context.Grobowce
                .FirstOrDefault(m => m.IdGrobowiec == id);
            if (grobowiec == null)
            {
                return NotFound();
            }

            return View(grobowiec);
        }

        // POST: Grobowiec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grobowce == null)
            {
                return Problem("Entity set 'DbCmentarzContext.Grobowce'  is null.");
            }
            var grobowiec = _context.Grobowce.GetById(id);
            if (grobowiec != null)
            {
                _context.Grobowce.Delete(grobowiec);
            }

             _context.Grobowce.SaveChanges(grobowiec);
            return RedirectToAction(nameof(Index));
        }

        private bool GrobowiecExists(int id)
        {
            return true;// (_context.Grobowce?.Any(e => e.IdGrobowiec == id)).GetValueOrDefault();
        }
    }
}
