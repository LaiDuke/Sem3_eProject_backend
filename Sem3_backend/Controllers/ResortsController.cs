using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sem3_backend.Models;

namespace Sem3_backend.Controllers
{
    [Authorize]
    public class ResortsController : Controller
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: Resorts
        [AllowAnonymous]
        public ActionResult Index()
        {
            var resorts = db.Resorts.Include(r => r.TouristSpot);
            return View(resorts.ToList());
        }

        // GET: Resorts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }

        // GET: Resorts/Create
        public ActionResult Create()
        {
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name");
            return View();
        }

        // POST: Resorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResortID,ImageUrl,Content,Name,Price,Quality,Location,TouristSpotID")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                db.Resorts.Add(resort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", resort.TouristSpotID);
            return View(resort);
        }

        // GET: Resorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", resort.TouristSpotID);
            return View(resort);
        }

        // POST: Resorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResortID,ImageUrl,Content,Name,Price,Quality,Location,TouristSpotID")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", resort.TouristSpotID);
            return View(resort);
        }

        // GET: Resorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }

        // POST: Resorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resort resort = db.Resorts.Find(id);
            db.Resorts.Remove(resort);
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
