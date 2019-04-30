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
    public class AircraftController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Aircraft
        [Authorize(Roles = "Admin, Managers, Users")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewBag.MakeSortParm = String.IsNullOrEmpty(sortOrder) ? "make_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var aircraft = from a in db.Aircraft
                           select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                aircraft = aircraft.Where(a => a.Make.Contains(searchString) || a.Model.Contains(searchString));
            }

            switch (sortOrder) 
            {
                case "model_desc":
                    aircraft = aircraft.OrderByDescending(a => a.Model);
                    break;
                case "make_desc":
                    aircraft = aircraft.OrderByDescending(a => a.Make);
                    break;
                default:
                    aircraft = aircraft.OrderBy(a => a.Pilot.FirstName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(aircraft.ToList());
        }

        // GET: Aircraft/Details/5
        [Authorize(Roles = "Admin, Managers, Users")]
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
        [Authorize(Roles = "Admin, Managers, Users")]
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
        [Authorize(Roles = "Admin, Managers, Users")]
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
        [Authorize(Roles = "Admin, Managers")]
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
