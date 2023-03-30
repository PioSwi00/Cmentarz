using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System.Data;

namespace Cmentarz.WEB.Controllers
{
    public class WlascicielController : Controller
    {
        private UoW unitOfWork = new UoW();


        public ActionResult Index()
        {
            var wlasciciele = unitOfWork.WlascicieleRepos.Get(includeProperties: "Uzytkownik");
            return View(wlasciciele.ToList());
        }

        public ActionResult Details(int id)
        {
            var wlasciciel = unitOfWork.WlascicieleRepos.GetByID(id);
            return View(wlasciciel);
        }

        public ActionResult Create()
        {
            PopulateWlascicieleDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Wlasciciel wlasciciel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.WlascicieleRepos.Insert(wlasciciel);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateWlascicieleDropDownList();
            return View(wlasciciel);
        }

        public ActionResult Edit(int id)
        {
            var wlasciciel = unitOfWork.WlascicieleRepos.GetByID(id);
            PopulateWlascicieleDropDownList();
            return View(wlasciciel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Wlasciciel wlasciciel)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.WlascicieleRepos.Update(wlasciciel);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateWlascicieleDropDownList(wlasciciel.IdWlasciciel);
            return View(wlasciciel);
        }

        private void PopulateWlascicieleDropDownList(object selectedWlasciciel = null)
        {
            var WlascicieleQuery = unitOfWork.WlascicieleRepos.Get(
             orderBy: q => q.OrderBy(d => d.IdWlasciciel));
            ViewBag.IdWlasciciel = new SelectList(WlascicieleQuery, "IdWlasciciel", "ID", selectedWlasciciel);
        }
        public ActionResult Delete(int id)
        {
            var wlasciciel = unitOfWork.WlascicieleRepos.GetByID(id);
            return View(wlasciciel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var wlasciciel = unitOfWork.WlascicieleRepos.GetByID(id);
            unitOfWork.WlascicieleRepos.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }


    }
}
