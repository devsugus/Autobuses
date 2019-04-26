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
    public class CiudadesController : BaseController
    {
       
        // GET: Ciudades
        public async Task<ActionResult> Index()
        {
            return View(await db.Ciudades.ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NombreCiudad")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudades);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NombreCiudad")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudades).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            db.Ciudades.Remove(ciudades);
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
