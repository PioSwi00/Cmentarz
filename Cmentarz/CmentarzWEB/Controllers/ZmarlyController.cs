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
    public class ZmarlyController : Controller
    {
        private UoW unitOfWork = new UoW();


        public ActionResult Index()
        {
            var zmarli = unitOfWork.ZmarliRepos.Get(includeProperties: "Grobowiec");
            return View(zmarli.ToList());
        }

        public ActionResult Details(int id)
        {
            var zmarly = unitOfWork.ZmarliRepos.GetByID(id);
            return View(zmarly);
        }

        public ActionResult Create()
        {
            PopulateZmarliDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zmarly zmarly)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.ZmarliRepos.Insert(zmarly);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateZmarliDropDownList();
            return View(zmarly);
        }

        public ActionResult Edit(int id)
        {
            var zmarly = unitOfWork.ZmarliRepos.GetByID(id);
            PopulateZmarliDropDownList();
            return View(zmarly);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Zmarly zmarly)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.ZmarliRepos.Update(zmarly);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateZmarliDropDownList(zmarly.IdZmarly);
            return View(zmarly);
        }

        private void PopulateZmarliDropDownList(object selectedZmarly = null)
        {
            var ZmarliQuery = unitOfWork.ZmarliRepos.Get(
             orderBy: q => q.OrderBy(d => d.IdZmarly));
            ViewBag.IdZmarly = new SelectList(ZmarliQuery, "IdZmarly", "ID", selectedZmarly);
        }
        public ActionResult Delete(int id)
        {
            var zmarly = unitOfWork.ZmarliRepos.GetByID(id);
            return View(zmarly);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var zmarly = unitOfWork.ZmarliRepos.GetByID(id);
            unitOfWork.ZmarliRepos.Delete(id);
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