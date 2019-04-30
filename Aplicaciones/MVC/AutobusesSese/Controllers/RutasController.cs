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

       
        // GET: Rutas
        public async Task<ActionResult> Index()
        {
            var rutas = await db.DameRutas();
            return View(rutas);
        }

        // GET: Rutas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Rutas rutas = await db.DameRuta(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            return View(rutas);
        }

        // GET: Rutas/Create
        public async Task<ActionResult> Create()
        {
            var origen = await db.DameCiudades();
            ViewBag.Origen = new SelectList(origen,"id","NombreCiudad");

            var destino = await db.DameCiudades();
            ViewBag.Destino = new SelectList(destino, "id", "NombreCiudad");

            
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
                db.CreaRuta(rutas);
                return RedirectToAction("Index");
            }
            var origen = await db.DameCiudades();
            ViewBag.Origen = new SelectList(origen, "id", "NombreCiudad");

            var destino = await db.DameCiudades();
            ViewBag.Destino = new SelectList(destino, "id", "NombreCiudad");

            return View(rutas);
        }

        // GET: Rutas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Rutas rutas = await db.DameRuta(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            var origen = await db.DameCiudades();
            ViewBag.Origen = new SelectList(origen, "id", "NombreCiudad");

            var destino = await db.DameCiudades();
            ViewBag.Destino = new SelectList(destino, "id", "NombreCiudad");
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
                db.ActualizaRuta(rutas);
                return RedirectToAction("Index");
            }
            ViewBag.Origen = await db.DameCiudades();
            ViewBag.Destino = await db.DameCiudades();
            return View(rutas);
        }

        // GET: Rutas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Rutas rutas = await db.DameRuta(id);
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
            Rutas rutas = await db.DameRuta(id);
            db.BorraRuta(rutas);
            return RedirectToAction("Index");
        }


    }
}
