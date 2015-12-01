using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ServiciosController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Servicios
        public async Task<ActionResult> Index()
        {
            var servicios = db.Servicios.Include(s => s.Restaurantes);
            return View(await servicios.ToListAsync());
        }

        // GET: Servicios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_servicio,nombre,descripcion,nit")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", servicios.nit);
            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", servicios.nit);
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_servicio,nombre,descripcion,nit")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", servicios.nit);
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Servicios servicios = await db.Servicios.FindAsync(id);
            db.Servicios.Remove(servicios);
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
