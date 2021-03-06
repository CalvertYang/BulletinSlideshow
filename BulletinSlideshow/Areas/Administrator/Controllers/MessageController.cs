﻿using System;
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
    public class MessageController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();
        private SignalR.IHubContext hubContext = SignalR.GlobalHost.ConnectionManager.GetHubContext<PushNotification>();

        //
        // GET: /Administrator/Message/

        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        //
        // GET: /Administrator/Message/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Message/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.LastUpdateOn = DateTime.Now;

                db.Messages.Add(message);
                db.SaveChanges();

                // Notification frontend to refresh page
                hubContext.Clients.All.refreshPage();

                return RedirectToAction("Index");
            }

            return View(message);
        }

        //
        // GET: /Administrator/Message/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        //
        // POST: /Administrator/Message/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                message.LastUpdateOn = DateTime.Now;

                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();

                // Notification frontend to refresh page
                hubContext.Clients.All.refreshPage();

                return RedirectToAction("Index");
            }
            return View(message);
        }

        //
        // POST: /Administrator/Message/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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