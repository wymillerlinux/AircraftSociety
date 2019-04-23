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
    public class AircraftController : Controller
    {
        private AirContext db = new AirContext();

        // GET: Aircraft
        public ActionResult Index()
        {
            var aircraft = db.Aircraft.Include(a => a.Pilot);
            return View(aircraft.ToList());
        }

        // GET: Aircraft/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircraft.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // GET: Aircraft/Create
        public ActionResult Create()
        {
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName");
            return View();
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AircraftID,Make,Model,Year,Callsign,IsActive,PilotID,FlightID")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Aircraft.Add(aircraft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName", aircraft.PilotID);
            return View(aircraft);
        }

        // GET: Aircraft/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircraft.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName", aircraft.PilotID);
            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AircraftID,Make,Model,Year,Callsign,IsActive,PilotID,FlightID")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName", aircraft.PilotID);
            return View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircraft.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aircraft aircraft = db.Aircraft.Find(id);
            db.Aircraft.Remove(aircraft);
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
