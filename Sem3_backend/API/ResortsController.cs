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
    public class ResortsController : ApiController
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: api/Resorts
        public IQueryable<Resort> GetResorts()
        {
            return db.Resorts;
        }

        // GET: api/Resorts/5
        [ResponseType(typeof(Resort))]
        public IHttpActionResult GetResort(int id)
        {
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return NotFound();
            }

            return Ok(resort);
        }

        // PUT: api/Resorts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResort(int id, Resort resort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resort.ResortID)
            {
                return BadRequest();
            }

            db.Entry(resort).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResortExists(id))
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

        // POST: api/Resorts
        [ResponseType(typeof(Resort))]
        public IHttpActionResult PostResort(Resort resort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Resorts.Add(resort);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resort.ResortID }, resort);
        }

        // DELETE: api/Resorts/5
        [ResponseType(typeof(Resort))]
        public IHttpActionResult DeleteResort(int id)
        {
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return NotFound();
            }

            db.Resorts.Remove(resort);
            db.SaveChanges();

            return Ok(resort);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResortExists(int id)
        {
            return db.Resorts.Count(e => e.ResortID == id) > 0;
        }
    }
}