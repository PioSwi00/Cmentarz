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
    public class OdwiedzajacyController : Controller
    {
        private UoW unitOfWork = new UoW();


        public ActionResult Index()
        {
            var odwiedzajacy = unitOfWork.OdwiedzajacyRepos.Get(includeProperties: "Grobowce");
            return View(odwiedzajacy.ToList());
        }

        public ActionResult Details(int id)
        {
            var odwiedzajacy = unitOfWork.OdwiedzajacyRepos.GetByID(id);
            return View(odwiedzajacy);
        }

        public ActionResult Create()
        {
            PopulateOdwiedzajacyDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Odwiedzajacy odwiedzajacy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.OdwiedzajacyRepos.Insert(odwiedzajacy);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateOdwiedzajacyDropDownList();
            return View(odwiedzajacy);
        }

        public ActionResult Edit(int id)
        {
            var odwiedzajacy = unitOfWork.OdwiedzajacyRepos.GetByID(id);
            PopulateOdwiedzajacyDropDownList();
            return View(odwiedzajacy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Odwiedzajacy odwiedzajacy)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.OdwiedzajacyRepos.Update(odwiedzajacy);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateOdwiedzajacyDropDownList(odwiedzajacy.IdOdwiedzajacy);
            return View(odwiedzajacy);
        }

        private void PopulateOdwiedzajacyDropDownList(object selectedOdwiedzajacy = null)
        {
            var OdwiedzajacyQuery = unitOfWork.OdwiedzajacyRepos.Get(
             orderBy: q => q.OrderBy(d => d.IdOdwiedzajacy));
            ViewBag.IdOdwiedzajacy = new SelectList(OdwiedzajacyQuery, "IdOdwiedzajacy", "ID", selectedOdwiedzajacy);
        }
        public ActionResult Delete(int id)
        {
            var odwiedzajacy = unitOfWork.OdwiedzajacyRepos.GetByID(id);
            return View(odwiedzajacy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Odwiedzajacy = unitOfWork.OdwiedzajacyRepos.GetByID(id);
            unitOfWork.OdwiedzajacyRepos.Delete(id);
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
