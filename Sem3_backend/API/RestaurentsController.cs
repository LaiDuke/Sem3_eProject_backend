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
    public class RestaurentsController : ApiController
    {
        private TouristSpotDbContext db = new TouristSpotDbContext();

        // GET: api/Restaurents
        public IQueryable<Restaurent> GetRestaurents()
        {
            return db.Restaurents;
        }

        // GET: api/Restaurents/5
        [ResponseType(typeof(Restaurent))]
        public IHttpActionResult GetRestaurent(int id)
        {
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return NotFound();
            }

            return Ok(restaurent);
        }

        // PUT: api/Restaurents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurent(int id, Restaurent restaurent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurent.RestaurentID)
            {
                return BadRequest();
            }

            db.Entry(restaurent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurentExists(id))
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

        // POST: api/Restaurents
        [ResponseType(typeof(Restaurent))]
        public IHttpActionResult PostRestaurent(Restaurent restaurent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurents.Add(restaurent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurent.RestaurentID }, restaurent);
        }

        // DELETE: api/Restaurents/5
        [ResponseType(typeof(Restaurent))]
        public IHttpActionResult DeleteRestaurent(int id)
        {
            Restaurent restaurent = db.Restaurents.Find(id);
            if (restaurent == null)
            {
                return NotFound();
            }

            db.Restaurents.Remove(restaurent);
            db.SaveChanges();

            return Ok(restaurent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurentExists(int id)
        {
            return db.Restaurents.Count(e => e.RestaurentID == id) > 0;
        }
    }
}