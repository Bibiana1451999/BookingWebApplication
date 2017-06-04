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
    public class RatingController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Rating
        public ActionResult Index(int? id)
        {

            var ra_rating = db.ra_rating.Include(r => r.h_hotel).Include(r => r.u_user);
            if (id != null)
                ra_rating = ra_rating.Where(e => e.ra_ratingId == id);
            return View(ra_rating.ToList());
        }

        // GET: Rating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ra_rating ra_rating = db.ra_rating.Find(id);
            if (ra_rating == null)
            {
                return HttpNotFound();
            }
            return View(ra_rating);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            ViewBag.ra_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name");
            ViewBag.ra_u_user = new SelectList(db.u_user, "u_username", "u_firstName");
            return View();
        }

        // POST: Rating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ra_ratingId,ra_rating1,ra_comment,ra_u_user,ra_h_hotel")] ra_rating ra_rating)
        {
            if (ModelState.IsValid)
            {
                db.ra_rating.Add(ra_rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ra_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", ra_rating.ra_h_hotel);
            ViewBag.ra_u_user = new SelectList(db.u_user, "u_username", "u_firstName", ra_rating.ra_u_user);
            return View(ra_rating);
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ra_rating ra_rating = db.ra_rating.Find(id);
            if (ra_rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ra_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", ra_rating.ra_h_hotel);
            ViewBag.ra_u_user = new SelectList(db.u_user, "u_username", "u_firstName", ra_rating.ra_u_user);
            return View(ra_rating);
        }

        // POST: Rating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ra_ratingId,ra_rating1,ra_comment,ra_u_user,ra_h_hotel")] ra_rating ra_rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ra_rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ra_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", ra_rating.ra_h_hotel);
            ViewBag.ra_u_user = new SelectList(db.u_user, "u_username", "u_firstName", ra_rating.ra_u_user);
            return View(ra_rating);
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ra_rating ra_rating = db.ra_rating.Find(id);
            if (ra_rating == null)
            {
                return HttpNotFound();
            }
            return View(ra_rating);
        }

        // POST: Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ra_rating ra_rating = db.ra_rating.Find(id);
            db.ra_rating.Remove(ra_rating);
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
