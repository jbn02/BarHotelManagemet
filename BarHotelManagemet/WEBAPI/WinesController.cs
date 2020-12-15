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
using BarHotelManagemet.Models;

namespace BarHotelManagemet.WEBAPI
{
    public class WinesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This function is to show wine list
        // GET: api/Wines
        public IQueryable<Wine> GetWines()
        {
            return db.Wines;
        }

        //This function is to show wine details
        // GET: api/Wines/5
        [ResponseType(typeof(Wine))]
        public IHttpActionResult GetWine(int id)
        {
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }

            return Ok(wine);
        }

        //This function is to update wine details
        // PUT: api/Wines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWine(int id, Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wine.ID)
            {
                return BadRequest();
            }

            db.Entry(wine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(id))
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

        ////This function is to add wine details
        // POST: api/Wines
        [ResponseType(typeof(Wine))]
        public IHttpActionResult PostWine(Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wines.Add(wine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wine.ID }, wine);
        }

        //This function is to delete wine details
        // DELETE: api/Wines/5
        [ResponseType(typeof(Wine))]
        public IHttpActionResult DeleteWine(int id)
        {
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return NotFound();
            }

            db.Wines.Remove(wine);
            db.SaveChanges();

            return Ok(wine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineExists(int id)
        {
            return db.Wines.Count(e => e.ID == id) > 0;
        }
    }
}