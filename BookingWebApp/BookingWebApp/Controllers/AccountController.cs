using BookingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookingWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        Entities7 db = new Entities7();
        private u_user slogin;

        public object EncryptDecrypt { get; private set; }

        public ActionResult Login()
        {
            return View();

        }

        public ActionResult Manage(int? id)
        {
            string username = User.Identity.Name;
            var u_user = db.u_user.Find(username);

            return View(u_user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Loginmodel model, string returnUrl)

          
        {
       u_user slogin;

            if (ModelState.IsValid)
            {
               // var p = EncryptDecrypt.Decrypt(model.Password, "a15s8f5s6e2s3g1w5");
                using (var db = new Entities7())
                {
                    var erg = from u in db.u_user
                              where u.u_username == model.UserName && u.u_password == model.Password
                              select u;
                    slogin = erg.FirstOrDefault();

                }

                if (slogin != null)
                {

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToLocal(returnUrl);  // Url  ?? "~/Home/Index"
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }




    }
}
