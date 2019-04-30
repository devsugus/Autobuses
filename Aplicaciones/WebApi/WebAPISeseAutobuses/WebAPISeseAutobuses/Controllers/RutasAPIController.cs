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
    public class RutasAPIController : ApiController
    {
        private AutobusesSeseEntities db = new AutobusesSeseEntities();

        // GET: api/RutasAPI
        public List<Ruta> GetRutas(string id, string id2)
        {
            //return db.Rutas;
            ConexionBBDD cnn = new ConexionBBDD("desaprendiendodb.database.windows.net", "AlumnoSese", "P@$$w0rd!", "AutobusesSese");
            Busqueda bss = new Busqueda(cnn);
            /*
            * Introduce ciudad de origen y ciudad de destino para poder devolver el listado de rutas.
            */
            var cosa = bss.rutas(id, id2);
           
            return cosa;
        }

        // GET: api/RutasAPI/5
        [ResponseType(typeof(Rutas))]
        public async Task<IHttpActionResult> GetRutas(int id)
        {
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return NotFound();
            }

            return Ok(rutas);
        }

        // PUT: api/RutasAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRutas(int id, Rutas rutas)
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
                await db.SaveChangesAsync();
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

        // POST: api/RutasAPI
        [ResponseType(typeof(Rutas))]
        public async Task<IHttpActionResult> PostRutas(Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutas.Add(rutas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rutas.Id }, rutas);
        }

        // DELETE: api/RutasAPI/5
        [ResponseType(typeof(Rutas))]
        public async Task<IHttpActionResult> DeleteRutas(int id)
        {
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return NotFound();
            }

            db.Rutas.Remove(rutas);
            await db.SaveChangesAsync();

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