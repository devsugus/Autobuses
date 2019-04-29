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
    public class CiudadesController : ApiController
    {
        private AutobusesSeseEntities db = new AutobusesSeseEntities();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string filter = Request.QueryString["Combined_Name"];
        //    Response.Clear();
        //    Response.ContentType = "application/json; charset=utf-8";
        //    Response.Write(ShowJSON(filter));
        //    Response.End();

        //}
        //private static string ShowJSON()
        //{

        //}

            [HttpGet]
            [Route("api/Ciudades/{NombreCiudad}")]
            
        public List<Ciudades> GetCiudadesNombre(string NombreCiudad)
        {
            return modelo.GetCiudades(NombreCiudad);
        }
        // GET: api/Ciudades
        public IQueryable<Ciudades> GetCiudades()
        {
            return db.Ciudades;
        }

        // GET: api/Ciudades/5
        [ResponseType(typeof(Ciudades))]
        public IHttpActionResult GetCiudades(int id)
        {
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return Ok(ciudades);
        }

        // PUT: api/Ciudades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCiudades(int id, Ciudades ciudades)
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
                db.SaveChanges();
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

        // POST: api/Ciudades
        [ResponseType(typeof(Ciudades))]
        public IHttpActionResult PostCiudades(Ciudades ciudades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudades.Add(ciudades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ciudades.Id }, ciudades);
        }

        // DELETE: api/Ciudades/5
        [ResponseType(typeof(Ciudades))]
        public IHttpActionResult DeleteCiudades(int id)
        {
            Ciudades ciudades = db.Ciudades.Find(id);
            if (ciudades == null)
            {
                return NotFound();
            }

            db.Ciudades.Remove(ciudades);
            db.SaveChanges();

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