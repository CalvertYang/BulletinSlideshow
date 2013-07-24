using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalR=Microsoft.AspNet.SignalR;
using BulletinSlideshow.Models;

namespace BulletinSlideshow.Areas.Administrator.Controllers
{
    [Authorize]
    public class InformationController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();
        private SignalR.IHubContext hubContext = SignalR.GlobalHost.ConnectionManager.GetHubContext<PushNotification>();

        //
        // GET: /Administrator/Information/

        public ActionResult Index()
        {
            var information = db.Information.Include(i => i.Category).OrderBy(i => i.CategoryId);
            return View(information.ToList());
        }

        //
        // GET: /Administrator/Information/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        //
        // POST: /Administrator/Information/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Information information)
        {
            if (ModelState.IsValid)
            {
                information.LastUpdateOn = DateTime.Now;
                information.CreatorId = db.Members.Where(m => m.Account == User.Identity.Name).FirstOrDefault().Id;

                db.Information.Add(information);
                db.SaveChanges();

                // Notification frontend to add information
                hubContext.Clients.All.addInformationContent(information, information.LastUpdateOn.Value.ToString("yyyy/MM/dd"));

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", information.CategoryId);
            return View(information);
        }

        //
        // GET: /Administrator/Information/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Information information = db.Information.Include(i => i.Creator).Where(i => i.Id == id).FirstOrDefault();
            if (information == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", information.CategoryId);
            return View(information);
        }

        //
        // POST: /Administrator/Information/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Information information)
        {
            if (ModelState.IsValid)
            {
                information.LastUpdateOn = DateTime.Now;
                information.ModifierId = db.Members.Where(m => m.Account == User.Identity.Name).FirstOrDefault().Id;

                db.Entry(information).State = EntityState.Modified;
                db.SaveChanges();

                // Notification frontend to edit information
                hubContext.Clients.All.editInformationContent(information, information.LastUpdateOn.Value.ToString("yyyy/MM/dd"));

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", information.CategoryId);
            return View(information);
        }

        //
        // POST: /Administrator/Information/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Information information = db.Information.Find(id);
            db.Information.Remove(information);
            db.SaveChanges();

            // Notification frontend to delete information
            hubContext.Clients.All.deleteInformationContent(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}