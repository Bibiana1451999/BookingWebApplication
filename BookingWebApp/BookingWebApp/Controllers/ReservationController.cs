using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingWebApp.Models;
using PagedList;

namespace BookingWebApp.Controllers
{
    public class ReservationController : Controller
    {
        private Entities4 db = new Entities4();

        // GET: Reservation
  
        public ActionResult Index()
        {
            var re_reservation = db.re_reservation.Include(r => r.r_room).Include(r => r.u_user);
            return View(re_reservation.ToList());

          
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            re_reservation re_reservation = db.re_reservation.Find(id);
            if (re_reservation == null)
            {
                return HttpNotFound();
            }
            return View(re_reservation);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            ViewBag.re_r_room = new SelectList(db.r_room, "r_number", "r_description");
            ViewBag.re_u_username = new SelectList(db.u_user, "u_username", "u_firstName");
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "re_reservationID,re_r_room,re_checkIn,re_checkOut,re_u_username")] re_reservation re_reservation)
        {
            if (ModelState.IsValid)
            {
                db.re_reservation.Add(re_reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.re_r_room = new SelectList(db.r_room, "r_number", "r_description", re_reservation.re_r_room);
            ViewBag.re_u_username = new SelectList(db.u_user, "u_username", "u_firstName", re_reservation.re_u_username);
            return View(re_reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            re_reservation re_reservation = db.re_reservation.Find(id);
            if (re_reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.re_r_room = new SelectList(db.r_room, "r_number", "r_description", re_reservation.re_r_room);
            ViewBag.re_u_username = new SelectList(db.u_user, "u_username", "u_firstName", re_reservation.re_u_username);
            return View(re_reservation);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "re_reservationID,re_r_room,re_checkIn,re_checkOut,re_u_username")] re_reservation re_reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(re_reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.re_r_room = new SelectList(db.r_room, "r_number", "r_description", re_reservation.re_r_room);
            ViewBag.re_u_username = new SelectList(db.u_user, "u_username", "u_firstName", re_reservation.re_u_username);
            return View(re_reservation);
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            re_reservation re_reservation = db.re_reservation.Find(id);
            if (re_reservation == null)
            {
                return HttpNotFound();
            }
            return View(re_reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            re_reservation re_reservation = db.re_reservation.Find(id);
            db.re_reservation.Remove(re_reservation);
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
