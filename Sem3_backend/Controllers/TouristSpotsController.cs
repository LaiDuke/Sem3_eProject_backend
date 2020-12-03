using System;
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
    public class TouristSpotsController : Controller
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: TouristSpots
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var tours = (from x in db.TouristSpots select x).OrderBy(x => x.TouristSpotID);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(tours.ToPagedList(pageNumber, pageSize));
        }

        // GET: TouristSpots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            return View(touristSpot);
        }

        // GET: TouristSpots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TouristSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TouristSpotID,Name,Content,Destination,ImageUrl")] TouristSpot touristSpot)
        {
            if (ModelState.IsValid)
            {
                db.TouristSpots.Add(touristSpot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(touristSpot);
        }

        // GET: TouristSpots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            return View(touristSpot);
        }

        // POST: TouristSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TouristSpotID,Name,Content,Destination,ImageUrl")] TouristSpot touristSpot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristSpot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(touristSpot);
        }

        // GET: TouristSpots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            return View(touristSpot);
        }

        // POST: TouristSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            db.TouristSpots.Remove(touristSpot);
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
