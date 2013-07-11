using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BulletinSlideshow.Models;
using System.Web.Security;
using Apputu.Library;

namespace BulletinSlideshow.Areas.Administrator.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private BulletinSlideshowContext db = new BulletinSlideshowContext();

        // 密碼雜湊所需的 Salt 亂數值
        private string saltValue = "9uyYNvhhqymer4dTe55ZszzFWtrUhf7use6n";
        private string passwordAlgorithm = "SHA512";

        //
        // GET: /Administrator/Member/

        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        //
        // GET: /Administrator/Member/Details/5

        public ActionResult Details(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // GET: /Administrator/Member/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Member/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                // Encrypt password by HashProvider
                member.Password = HashProvider.ComputeHash(member.Password, passwordAlgorithm, saltValue);

                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //
        // GET: /Administrator/Member/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //
        // POST: /Administrator/Member/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(Member member)
        public ActionResult Edit(int Id, string Name)
        {
            Member member = db.Members.Find(Id);

            if (member != null)
            {
                member.Name = Name;

                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // POST: /Administrator/Member/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            Member member = db.Members.Find(Id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(int Id, string Password)
        {
            try
            {
                Member member = db.Members.Find(Id);
                member.Password = HashProvider.ComputeHash(Password, passwordAlgorithm, saltValue);
                db.SaveChanges();

                return JavaScript("bootbox.alert('Password Changed Successfully!');");
            }
            catch
            {
                return JavaScript("bootbox.alert('Password Changed Failed!');");
            }
        }

        #region Login/Logout

        // 
        // GET: /Administrator/Member/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        // 
        // POST: /Administrator/Member/Login

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string account, string password, string returnUrl)
        {
            if (ValidateUser(account, password))
            {
                FormsAuthentication.SetAuthCookie(account, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToRoute("Administrator", new { controller = "Information", action = "Index" });
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }

            return View();
        }

        //
        // GET: /Administrator/Admin/Logout

        [AllowAnonymous]
        public ActionResult Logout()
        {
            // 清除表單驗證的 Cookies
            FormsAuthentication.SignOut();

            // 清除所有曾經寫入過的 Session 資料
            Session.Clear();

            return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
        }

        #region Methods

        /// <summary>
        /// 進行會員驗證
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">明文密碼</param>
        /// <returns>驗證結果</returns>
        private bool ValidateUser(string account, string password)
        {
            bool isVerified = false;
            var member = db.Members.Where(m => m.Account == account).FirstOrDefault();

            if (member != null)
            {
                isVerified = HashProvider.VerifyHash(password, passwordAlgorithm, member.Password);
            }

            if (!isVerified)
            {
                ModelState.AddModelError("", "您輸入的帳號或密碼錯誤");
            }
            else
            {
                member.LastLoginOn = DateTime.Now;
                db.SaveChanges();
            }

            return isVerified;
        }

        #endregion

        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}