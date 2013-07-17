using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalR = Microsoft.AspNet.SignalR;
using BulletinSlideshow.Models;

namespace BulletinSlideshow.Areas.Administrator.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();
        private SignalR.IHubContext hubContext = SignalR.GlobalHost.ConnectionManager.GetHubContext<PushNotification>();

        //
        // GET: /Administrator/Category/

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Administrator/Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

                // Notification frontend to add category
                hubContext.Clients.All.addInformationCategory(category);

                return RedirectToAction("Index");
            }

            return View(category);
        }

        //
        // GET: /Administrator/Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Administrator/Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

                // Notification frontend to edit category
                hubContext.Clients.All.editInformationCategory(category);

                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();

            // Notification frontend to delete category
            hubContext.Clients.All.deleteInformationCategory(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}