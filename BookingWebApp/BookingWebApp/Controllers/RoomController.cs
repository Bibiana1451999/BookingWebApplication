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
    public class RoomController : Controller
    {
        private Entities7 db = new Entities7();

        // GET: Room
        public ActionResult Index(string hotelFilter, string roomFilter)
        {
            var r_room = db.r_room.Include(r => r.h_hotel).Include(r => r.tr_typeOfRoom);
            if (hotelFilter != null && hotelFilter != "")
                r_room = r_room.Where(r => r.h_hotel.h_name == hotelFilter);
            if (roomFilter != null && roomFilter != "")
                r_room = r_room.Where(r => r.r_tr_typeOfRoom== roomFilter);

            ViewBag.hotelFilter = new SelectList(db.h_hotel, "h_name", "h_name");
        
            ViewBag.roomFilter = new SelectList(db.tr_typeOfRoom, "tr_type", "tr_type");
            return View(r_room.ToList());
        }

        // GET: Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            r_room r_room = db.r_room.Find(id);
            if (r_room == null)
            {
                return HttpNotFound();
            }
            return View(r_room);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            ViewBag.r_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name");
            ViewBag.r_tr_typeOfRoom = new SelectList(db.tr_typeOfRoom, "tr_type", "tr_type");
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "r_number,r_h_hotel,r_beds,r_price,r_description,r_tr_typeOfRoom")] r_room r_room)
        {
            if (ModelState.IsValid)
            {
                db.r_room.Add(r_room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.r_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", r_room.r_h_hotel);
            ViewBag.r_tr_typeOfRoom = new SelectList(db.tr_typeOfRoom, "tr_type", "tr_type", r_room.r_tr_typeOfRoom);
            return View(r_room);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            r_room r_room = db.r_room.Find(id);
            if (r_room == null)
            {
                return HttpNotFound();
            }
            ViewBag.r_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", r_room.r_h_hotel);
            ViewBag.r_tr_typeOfRoom = new SelectList(db.tr_typeOfRoom, "tr_type", "tr_type", r_room.r_tr_typeOfRoom);
            return View(r_room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "r_number,r_h_hotel,r_beds,r_price,r_description,r_tr_typeOfRoom")] r_room r_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(r_room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.r_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", r_room.r_h_hotel);
            ViewBag.r_tr_typeOfRoom = new SelectList(db.tr_typeOfRoom, "tr_type", "tr_type", r_room.r_tr_typeOfRoom);
            return View(r_room);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            r_room r_room = db.r_room.Find(id);
            if (r_room == null)
            {
                return HttpNotFound();
            }
            return View(r_room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            r_room r_room = db.r_room.Find(id);
            db.r_room.Remove(r_room);
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
