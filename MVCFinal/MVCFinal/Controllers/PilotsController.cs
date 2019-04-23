using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCFinal.DAL;
using MVCFinal.Models;

namespace MVCFinal.Controllers
{
    public class PilotsController : Controller
    {
        private AirContext db = new AirContext();

        // GET: Pilots
        public ActionResult Index()
        {
            return View(db.Pilots.ToList());
        }

        // GET: Pilots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilot pilot = db.Pilots.Find(id);
            if (pilot == null)
            {
                return HttpNotFound();
            }
            return View(pilot);
        }

        // GET: Pilots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pilots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PilotID,FirstName,LastName,FlightID,AircraftID")] Pilot pilot)
        {
            if (ModelState.IsValid)
            {
                db.Pilots.Add(pilot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pilot);
        }

        // GET: Pilots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilot pilot = db.Pilots.Find(id);
            if (pilot == null)
            {
                return HttpNotFound();
            }
            return View(pilot);
        }

        // POST: Pilots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PilotID,FirstName,LastName,FlightID,AircraftID")] Pilot pilot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pilot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pilot);
        }

        // GET: Pilots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilot pilot = db.Pilots.Find(id);
            if (pilot == null)
            {
                return HttpNotFound();
            }
            return View(pilot);
        }

        // POST: Pilots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pilot pilot = db.Pilots.Find(id);
            db.Pilots.Remove(pilot);
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
