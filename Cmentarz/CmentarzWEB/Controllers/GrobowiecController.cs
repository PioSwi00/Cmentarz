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
    public class GrobowiecController : Controller
    {
        private UoW unitOfWork = new UoW();


        public ActionResult Index()
        {
            var grobowce = unitOfWork.GrobowceRepos.Get(includeProperties: "Zmarli");
            return View(grobowce.ToList());
        }

        public ActionResult Details(int id)
        {
            var grobowiec = unitOfWork.GrobowceRepos.GetByID(id);
            return View(grobowiec);
        }

        public ActionResult Create()
        {
            PopulateGrobowceDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grobowiec grobowiec)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GrobowceRepos.Insert(grobowiec);
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
            return View(grobowiec);
        }

        public ActionResult Edit(int id)
        {
            var grobowiec = unitOfWork.GrobowceRepos.GetByID(id);
            PopulateGrobowceDropDownList();
            return View(grobowiec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Grobowiec grobowiec)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GrobowceRepos.Update(grobowiec);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateGrobowceDropDownList(grobowiec.IdGrobowiec);
            return View(grobowiec);
        }

        private void PopulateGrobowceDropDownList(object selectedGrobowiec = null)
        {
            var GrobowceQuery = unitOfWork.GrobowceRepos.Get(
             orderBy: q => q.OrderBy(d => d.IdGrobowiec));
            ViewBag.IdGrobowiec = new SelectList(GrobowceQuery, "IdGrobowiec", "ID", selectedGrobowiec);
        }
        public ActionResult Delete(int id)
        {
            var grobowiec = unitOfWork.GrobowceRepos.GetByID(id);
            return View(grobowiec);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var grobowiec = unitOfWork.GrobowceRepos.GetByID(id);
            unitOfWork.GrobowceRepos.Delete(id);
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
