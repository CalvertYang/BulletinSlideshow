using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BulletinSlideshow.Models;

namespace BulletinSlideshow.Areas.Administrator.Controllers
{
    public class ParameterController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();

        //
        // GET: /Administrator/Parameter/

        public ActionResult Index()
        {
            return View(db.Parameters.ToList());
        }

        //
        // GET: /Administrator/Parameter/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Parameter parameter = db.Parameters.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /Administrator/Parameter/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parameter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}