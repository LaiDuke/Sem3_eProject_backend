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
    public class RestaurentsController : Controller
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: Restaurents
        public ActionResult Index()
        {
            var restaurents = db.Restaurents.Include(r => r.TouristSpot);
            return View(restaurents.ToList());
        }

        // GET: Restaurents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return HttpNotFound();
            }
            return View(restaurent);
        }

        // GET: Restaurents/Create
        public ActionResult Create()
        {
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name");
            return View();
        }

        // POST: Restaurents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurentID,ImageUrl,Content,Name,Price,Quality,Location,TouristSpotID")] Restaurent restaurent)
        {
            if (ModelState.IsValid)
            {
                db.Restaurents.Add(restaurent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", restaurent.TouristSpotID);
            return View(restaurent);
        }

        // GET: Restaurents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return HttpNotFound();
            }
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", restaurent.TouristSpotID);
            return View(restaurent);
        }

        // POST: Restaurents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurentID,ImageUrl,Content,Name,Price,Quality,Location,TouristSpotID")] Restaurent restaurent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TouristSpotID = new SelectList(db.TouristSpots, "TouristSpotID", "Name", restaurent.TouristSpotID);
            return View(restaurent);
        }

        // GET: Restaurents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return HttpNotFound();
            }
            return View(restaurent);
        }

        // POST: Restaurents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurent restaurent = db.Restaurents.Find(id);
            db.Restaurents.Remove(restaurent);
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
