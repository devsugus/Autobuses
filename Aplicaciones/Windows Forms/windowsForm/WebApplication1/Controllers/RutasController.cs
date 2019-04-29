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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RutasController : ApiController
    {
        private AutobusesSeseEntities db = new AutobusesSeseEntities();

        // GET: api/Rutas
        public IQueryable<Rutas> GetRutas()
        {
            return db.Rutas;
        }

        // GET: api/Rutas/5
        [ResponseType(typeof(Rutas))]
        public IHttpActionResult GetRutas(int id)
        {
            Rutas rutas = db.Rutas.Find(id);
            if (rutas == null)
            {
                return NotFound();
            }

            return Ok(rutas);
        }

        // PUT: api/Rutas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRutas(int id, Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutas.Id)
            {
                return BadRequest();
            }

            db.Entry(rutas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutasExists(id))
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

        // POST: api/Rutas
        [ResponseType(typeof(Rutas))]
        public IHttpActionResult PostRutas(Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutas.Add(rutas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rutas.Id }, rutas);
        }

        // DELETE: api/Rutas/5
        [ResponseType(typeof(Rutas))]
        public IHttpActionResult DeleteRutas(int id)
        {
            Rutas rutas = db.Rutas.Find(id);
            if (rutas == null)
            {
                return NotFound();
            }

            db.Rutas.Remove(rutas);
            db.SaveChanges();

            return Ok(rutas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutasExists(int id)
        {
            return db.Rutas.Count(e => e.Id == id) > 0;
        }
    }
}