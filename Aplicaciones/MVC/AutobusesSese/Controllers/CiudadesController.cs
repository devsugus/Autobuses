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
        [AcceptVerbs("Get", "Post")]
        public ActionResult VerificarCiudad(string NombreCiudad)
        {
            

            AutobusesSeseEntities1 db = new AutobusesSeseEntities1();

            var nombre = (from Nombre in db.Ciudades
                          where Nombre.NombreCiudad == NombreCiudad
                          select Nombre).ToList();

            if (nombre.Count == 0)
            {
                return Json(data: true);
            }
            else
            {
                return Json(data:$"La ciudad {NombreCiudad} ya existe.");
            }
        }

        // GET: Ciudades
        public async Task<ActionResult> Index()
        {
            var ciudades = await db.DameCiudades();
            return View(ciudades);
        }

        // GET: Ciudades/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Ciudades ciudades = await db.DameCiudad(id);
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
                db.CreaCiudad(ciudades);
                return RedirectToAction("Index");
            }

            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Ciudades ciudades = await db.DameCiudad(id);
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
                db.ActualizaCiudad(ciudades);
                return RedirectToAction("Index");
            }
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Ciudades ciudades = await db.DameCiudad(id);
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
            Ciudades ciudades = await db.DameCiudad(id);
            db.BorraCiudad(ciudades);
            return RedirectToAction("Index");
        }

    }
}

