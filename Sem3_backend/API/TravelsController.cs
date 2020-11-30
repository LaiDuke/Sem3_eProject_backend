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
    public class TravelsController : ApiController
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: api/Travels
        public IQueryable<Travel> GetTravels()
        {
            return db.Travels;
        }

        // GET: api/Travels/5
        [ResponseType(typeof(Travel))]
        public IHttpActionResult GetTravel(int id)
        {
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        // PUT: api/Travels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravel(int id, Travel travel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travel.TravelID)
            {
                return BadRequest();
            }

            db.Entry(travel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExists(id))
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

        // POST: api/Travels
        [ResponseType(typeof(Travel))]
        public IHttpActionResult PostTravel(Travel travel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Travels.Add(travel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = travel.TravelID }, travel);
        }

        // DELETE: api/Travels/5
        [ResponseType(typeof(Travel))]
        public IHttpActionResult DeleteTravel(int id)
        {
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return NotFound();
            }

            db.Travels.Remove(travel);
            db.SaveChanges();

            return Ok(travel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravelExists(int id)
        {
            return db.Travels.Count(e => e.TravelID == id) > 0;
        }
    }
}