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
    public class ServicesController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Services
        public ActionResult Index(string sortOrder)
        {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


                var se_services = db.se_services.Include(s => s.h_hotel);

                switch (sortOrder)
                {
                    case "name_desc":
                        se_services =se_services.OrderByDescending(u => u.se_services1);
                        break;
                    default:  // Name ascending 
                        se_services = se_services.OrderBy(u => u.se_services1);
                        break;
                }

               
            return View(se_services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            se_services se_services = db.se_services.Find(id);
            if (se_services == null)
            {
                return HttpNotFound();
            }
            return View(se_services);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.se_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "se_serviceid,se_services1,se_h_hotel")] se_services se_services)
        {
            if (ModelState.IsValid)
            {
                db.se_services.Add(se_services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.se_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", se_services.se_h_hotel);
            return View(se_services);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            se_services se_services = db.se_services.Find(id);
            if (se_services == null)
            {
                return HttpNotFound();
            }
            ViewBag.se_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", se_services.se_h_hotel);
            return View(se_services);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "se_serviceid,se_services1,se_h_hotel")] se_services se_services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(se_services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.se_h_hotel = new SelectList(db.h_hotel, "h_hotelid", "h_name", se_services.se_h_hotel);
            return View(se_services);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            se_services se_services = db.se_services.Find(id);
            if (se_services == null)
            {
                return HttpNotFound();
            }
            return View(se_services);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            se_services se_services = db.se_services.Find(id);
            db.se_services.Remove(se_services);
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
