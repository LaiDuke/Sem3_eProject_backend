﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Sem3_backend.Models;

namespace Sem3_backend.Controllers
{
    [Authorize]
    public class TransportsController : Controller
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: Transports
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var transports = (from x in db.Transports select x).Include(t => t.Travel).OrderBy(x => x.TransportID);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(transports.ToPagedList(pageNumber, pageSize));
        }

        // GET: Transports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Include(t => t.Travel).SingleOrDefault(x => x.TransportID == id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transports/Create
        public ActionResult Create()
        {
            ViewBag.TravelID = new SelectList(db.Travels, "TravelID", "Name");
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportID,Name,ImageUrl,Content,TravelID")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Transports.Add(transport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TravelID = new SelectList(db.Travels, "TravelID", "ImageUrl", transport.TravelID);
            return View(transport);
        }

        // GET: Transports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            ViewBag.TravelID = new SelectList(db.Travels, "TravelID", "ImageUrl", transport.TravelID);
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportID,Name,ImageUrl,Content,TravelID")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TravelID = new SelectList(db.Travels, "TravelID", "ImageUrl", transport.TravelID);
            return View(transport);
        }

        // GET: Transports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = db.Transports.Find(id);
            db.Transports.Remove(transport);
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
