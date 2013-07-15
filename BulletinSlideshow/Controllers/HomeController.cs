using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BulletinSlideshow.Models;

namespace BulletinSlideshow.Controllers
{
    public class HomeController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var information = db.Information.Include(i => i.Category).OrderBy(i => i.CategoryId);
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Parameter = db.Parameters.FirstOrDefault();
            var message = db.Messages.FirstOrDefault();
            if (message != null)
            {
                ViewBag.NotifyMessage = message.NotifyMessage;
            }
            return View(information.ToList());
        }

    }
}
