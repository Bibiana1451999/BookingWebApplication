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
    public class HotelController : Controller
    {
        private Entities4 db = new Entities4();

        // GET: Hotel
   
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
          //  ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
           
                        var h_hotel = db.h_hotel.Include(h => h.d_destination).Include(h => h.ho_host);

            if (searchString != null)
            {
               
                page = 1;
            }
            else { searchString = currentFilter; }
            ViewBag.CurrentFilter = searchString;

            //var hotels = from h in db.h_hotel
            //             select h;
            if (!String.IsNullOrEmpty(searchString)) { h_hotel = h_hotel.Where(h => h.h_name.ToUpper().Contains(searchString.ToUpper())); }

            switch (sortOrder)
            {
                case "name_desc":
                    h_hotel = h_hotel.OrderByDescending(s => s.h_name);
                    break;
               
                
                default: // Name ascending
                    h_hotel = h_hotel.OrderBy(s => s.h_name);
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(h_hotel.ToPagedList(pageNumber, pageSize));
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_hotel h_hotel = db.h_hotel.Find(id);
            if (h_hotel == null)
            {
                return HttpNotFound();
            }
            return View(h_hotel);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            ViewBag.h_d_city = new SelectList(db.d_destination, "d_city", "d_city");
            ViewBag.h_ho_host = new SelectList(db.ho_host, "ho_hostname", "ho_firstname");
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "h_hotelid,h_name,h_stars,h_address,h_zip,h_d_city,h_description,h_d_country,h_ho_host")] h_hotel h_hotel)
        {
            if (ModelState.IsValid)
            {
                db.h_hotel.Add(h_hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.h_d_city = new SelectList(db.d_destination, "d_city", "d_city", h_hotel.h_d_city);
            ViewBag.h_ho_host = new SelectList(db.ho_host, "ho_hostname", "ho_firstname", h_hotel.h_ho_host);
            return View(h_hotel);
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_hotel h_hotel = db.h_hotel.Find(id);
            if (h_hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.h_d_city = new SelectList(db.d_destination, "d_city", "d_city", h_hotel.h_d_city);
            ViewBag.h_ho_host = new SelectList(db.ho_host, "ho_hostname", "ho_firstname", h_hotel.h_ho_host);
            return View(h_hotel);
        }

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "h_hotelid,h_name,h_stars,h_address,h_zip,h_d_city,h_description,h_d_country,h_ho_host")] h_hotel h_hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h_hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.h_d_city = new SelectList(db.d_destination, "d_city", "d_city", h_hotel.h_d_city);
            ViewBag.h_ho_host = new SelectList(db.ho_host, "ho_hostname", "ho_firstname", h_hotel.h_ho_host);
            return View(h_hotel);
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_hotel h_hotel = db.h_hotel.Find(id);
            if (h_hotel == null)
            {
                return HttpNotFound();
            }
            return View(h_hotel);
        }


        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            h_hotel h_hotel = db.h_hotel.Find(id);
            db.h_hotel.Remove(h_hotel);
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
