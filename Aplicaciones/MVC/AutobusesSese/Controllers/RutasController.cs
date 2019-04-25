using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutobusesSese.Models;

namespace AutobusesSese.Controllers
{
    public class RutasController : BaseController
    {
        private AutobusesSeseEntities db = new AutobusesSeseEntities();

        // GET: Rutas
        public async Task<ActionResult> Index()
        {
            var rutas = db.Rutas.Include(r => r.Ciudades).Include(r => r.Ciudades1);
            return View(await rutas.ToListAsync());
        }

        // GET: Rutas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            return View(rutas);
        }

        // GET: Rutas/Create
        public ActionResult Create()
        {
            ViewBag.Origen = new SelectList(db.Ciudades, "Id", "NombreCiudad");
            ViewBag.Destino = new SelectList(db.Ciudades, "Id", "NombreCiudad");
            return View();
        }

        // POST: Rutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Origen,Destino,Km,Tiempo,Precio")] Rutas rutas)
        {
            if (ModelState.IsValid)
            {
                db.Rutas.Add(rutas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Origen = new SelectList(db.Ciudades, "Id", "NombreCiudad", rutas.Origen);
            ViewBag.Destino = new SelectList(db.Ciudades, "Id", "NombreCiudad", rutas.Destino);
            return View(rutas);
        }

        // GET: Rutas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Origen = new SelectList(db.Ciudades, "Id", "NombreCiudad", rutas.Origen);
            ViewBag.Destino = new SelectList(db.Ciudades, "Id", "NombreCiudad", rutas.Destino);
            return View(rutas);
        }

        // POST: Rutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Origen,Destino,Km,Tiempo,Precio")] Rutas rutas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Origen = new SelectList(db.Ciudades, "Id", "NombreCiudad", rutas.Origen);
            ViewBag.Destino = new SelectList(db.Ciudades, "Id", "NombreCiudad", rutas.Destino);
            return View(rutas);
        }

        // GET: Rutas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            return View(rutas);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rutas rutas = await db.Rutas.FindAsync(id);
            db.Rutas.Remove(rutas);
            await db.SaveChangesAsync();
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
