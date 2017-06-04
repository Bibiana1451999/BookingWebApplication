using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingWebApp.Models;

namespace BookingWebApp.Controllers
{
    public class UserController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: User
        public ActionResult Index(string sortOrder)

        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            var users = db.u_user.Include(u => u.ra_rating);

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.u_firstName);
                    break;
                default:  // Name ascending 
                    users = users.OrderBy(u => u.u_firstName);
                    break;
            }

            return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_user u_user = db.u_user.Find(id);
            if (u_user == null)
            {
                return HttpNotFound();
            }
            return View(u_user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_username,u_firstName,u_lastName,u_password")] u_user u_user)
        {
            if (ModelState.IsValid)
            {
                db.u_user.Add(u_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(u_user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_user u_user = db.u_user.Find(id);
            if (u_user == null)
            {
                return HttpNotFound();
            }
            return View(u_user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_username,u_firstName,u_lastName,u_password")] u_user u_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(u_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u_user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_user u_user = db.u_user.Find(id);
            if (u_user == null)
            {
                return HttpNotFound();
            }
            return View(u_user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            u_user u_user = db.u_user.Find(id);
            db.u_user.Remove(u_user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
