﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sem3_backend.Models;
using PagedList;

namespace Sem3_backend.Controllers
{
    [Authorize]
    public class TravelsController : Controller
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: Travels
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var travels = (from x in db.Travels select x).Include(t => t.TouristSpot).OrderBy(x => x.TravelID);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(travels.ToPagedList(pageNumber, pageSize));
        }

        // GET: Travels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Include(t => t.TouristSpot).SingleOrDefault(x => x.TravelID == id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // GET: Travels/Create
        public ActionResult Create()
        {
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name");
            return View();
        }

        // POST: Travels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TravelID,ImageUrl,Name,Content,TouristSpotID")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Travels.Add(travel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", travel.TouristSpotID);
            return View(travel);
        }

        // GET: Travels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", travel.TouristSpotID);
            return View(travel);
        }

        // POST: Travels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TravelID,ImageUrl,Name,Content,TouristSpotID")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", travel.TouristSpotID);
            return View(travel);
        }

        // GET: Travels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel travel = db.Travels.Find(id);
            db.Travels.Remove(travel);
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
