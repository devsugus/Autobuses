using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPISeseAutobuses.Models;

namespace WebAPISeseAutobuses.Controllers
{
    public class CiudadesAPIController : ApiController
    {
        private AutobusesSeseEntities db = new AutobusesSeseEntities();

        // GET: api/CiudadesAPI
        public IQueryable<Ciudades> GetCiudades()
        {
            return db.Ciudades;
        }

        // GET: api/CiudadesAPI/5
        [ResponseType(typeof(Ciudades))]
        public async Task<IHttpActionResult> GetCiudades(int id)
        {
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return Ok(ciudades);
        }

        // PUT: api/CiudadesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCiudades(int id, Ciudades ciudades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ciudades.Id)
            {
                return BadRequest();
            }

            db.Entry(ciudades).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadesExists(id))
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

        // POST: api/CiudadesAPI
        [ResponseType(typeof(Ciudades))]
        public async Task<IHttpActionResult> PostCiudades(Ciudades ciudades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudades.Add(ciudades);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ciudades.Id }, ciudades);
        }

        // DELETE: api/CiudadesAPI/5
        [ResponseType(typeof(Ciudades))]
        public async Task<IHttpActionResult> DeleteCiudades(int id)
        {
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return NotFound();
            }

            db.Ciudades.Remove(ciudades);
            await db.SaveChangesAsync();

            return Ok(ciudades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CiudadesExists(int id)
        {
            return db.Ciudades.Count(e => e.Id == id) > 0;
        }
    }
}