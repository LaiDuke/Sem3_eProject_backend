using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sem3_backend.Models;

namespace Sem3_backend.API
{
    public class TouristSpotsController : ApiController
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: api/TouristSpots
        public IQueryable<TouristSpot> GetTouristSpots()
        {
            return db.TouristSpots;
        }

        // GET: api/TouristSpots/5
        [ResponseType(typeof(TouristSpot))]
        public IHttpActionResult GetTouristSpot(int id)
        {
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return NotFound();
            }

            return Ok(touristSpot);
        }

        // PUT: api/TouristSpots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTouristSpot(int id, TouristSpot touristSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != touristSpot.TouristSpotID)
            {
                return BadRequest();
            }

            db.Entry(touristSpot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristSpotExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TouristSpots
        [ResponseType(typeof(TouristSpot))]
        public IHttpActionResult PostTouristSpot(TouristSpot touristSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TouristSpots.Add(touristSpot);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = touristSpot.TouristSpotID }, touristSpot);
        }

        // DELETE: api/TouristSpots/5
        [ResponseType(typeof(TouristSpot))]
        public IHttpActionResult DeleteTouristSpot(int id)
        {
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return NotFound();
            }

            db.TouristSpots.Remove(touristSpot);
            db.SaveChanges();

            return Ok(touristSpot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TouristSpotExists(int id)
        {
            return db.TouristSpots.Count(e => e.TouristSpotID == id) > 0;
        }
    }
}