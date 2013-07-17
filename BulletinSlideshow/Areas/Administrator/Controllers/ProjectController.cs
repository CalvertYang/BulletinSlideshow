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
    public class ProjectController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();
        private SignalR.IHubContext hubContext = SignalR.GlobalHost.ConnectionManager.GetHubContext<PushNotification>();

        //
        // GET: /Administrator/Project/

        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        //
        // GET: /Administrator/Project/Details/5

        public ActionResult Details(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Administrator/Project/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Project/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();

                // Notification frontend to add project
                hubContext.Clients.All.addProject(project);

                return RedirectToAction("Index");
            }

            return View(project);
        }

        //
        // GET: /Administrator/Project/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Administrator/Project/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                project.LastUpdateOn = DateTime.Now;

                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();

                // Notification frontend to edit project
                hubContext.Clients.All.editProject(project);

                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // POST: /Administrator/Project/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();

            // Notification frontend to refresh page
            hubContext.Clients.All.refreshPage();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}