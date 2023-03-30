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
    public class UzytkownikController : Controller
    {
        private UoW unitOfWork = new UoW();


        public ActionResult Index()
        {
            var uzytkownik = unitOfWork.UzytkownicyRepos.Get();
            return View(uzytkownik.ToList());
        }

        public ActionResult Details(int id)
        {
            var uzytkownik = unitOfWork.UzytkownicyRepos.GetByID(id);
            return View(uzytkownik);
        }

        public ActionResult Create()
        {
            PopulateGrobowceDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uzytkownik uzytkownik)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.UzytkownicyRepos.Insert(uzytkownik);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateGrobowceDropDownList();
            return View(uzytkownik);
        }

        public ActionResult Edit(int id)
        {
            var uzytkownik = unitOfWork.UzytkownicyRepos.GetByID(id);
            PopulateGrobowceDropDownList();
            return View(uzytkownik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Uzytkownik uzytkownik)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.UzytkownicyRepos.Update(uzytkownik);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateGrobowceDropDownList(uzytkownik.IdUzytkownik);
            return View(uzytkownik);
        }

        private void PopulateGrobowceDropDownList(object selectedUzytkownik = null)
        {
            var GrobowceQuery = unitOfWork.UzytkownicyRepos.Get(
             orderBy: q => q.OrderBy(d => d.IdUzytkownik));
            ViewBag.IdUzytkownik = new SelectList(GrobowceQuery, "IdUzytkownik", "ID", selectedUzytkownik);
        }
        public ActionResult Delete(int id)
        {
            var uzytkownik = unitOfWork.UzytkownicyRepos.GetByID(id);
            return View(uzytkownik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var uzytkownik = unitOfWork.UzytkownicyRepos.GetByID(id);
            unitOfWork.UzytkownicyRepos.Delete(id);
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
