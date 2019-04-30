using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.DAL;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class FlightController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Flight
        [Authorize(Roles = "Admin, Managers, Users")]
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.Aircraft).Include(f => f.Pilot);
            return View(flights.ToList());
        }

        // GET: Flight/Details/5
        [Authorize(Roles = "Admin, Managers, Users")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flight/Create
        [Authorize(Roles = "Admin, Managers, Users")]
        public ActionResult Create()
        {
            ViewBag.AircraftID = new SelectList(db.Aircraft, "AircraftID", "Make");
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName");
            return View();
        }

        // POST: Flight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightID,DepartingAirport,ArrivingAirport,AircraftID,PilotID")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AircraftID = new SelectList(db.Aircraft, "AircraftID", "Make", flight.AircraftID);
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName", flight.PilotID);
            return View(flight);
        }

        // GET: Flight/Edit/5
        [Authorize(Roles = "Admin, Managers, Users")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.AircraftID = new SelectList(db.Aircraft, "AircraftID", "Make", flight.AircraftID);
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName", flight.PilotID);
            return View(flight);
        }

        // POST: Flight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightID,DepartingAirport,ArrivingAirport,AircraftID,PilotID")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AircraftID = new SelectList(db.Aircraft, "AircraftID", "Make", flight.AircraftID);
            ViewBag.PilotID = new SelectList(db.Pilots, "PilotID", "FirstName", flight.PilotID);
            return View(flight);
        }

        // GET: Flight/Delete/5
        [Authorize(Roles = "Admin, Managers")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
