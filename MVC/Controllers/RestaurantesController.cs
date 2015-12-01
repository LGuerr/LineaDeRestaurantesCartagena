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
    public class RestaurantesController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Restaurantes
        public async Task<ActionResult> Index()
        {
            var restaurantes = db.Restaurantes.Include(r => r.Imegenes).Include(r => r.Zona1).Include(r => r.Cocina).Include(r => r.User);
            return View(await restaurantes.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantes restaurantes = await db.Restaurantes.FindAsync(id);
            if (restaurantes == null)
            {
                return HttpNotFound();
            }
            return View(restaurantes);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            ViewBag.nit = new SelectList(db.Imegenes, "nit", "logo");
            ViewBag.zona = new SelectList(db.Zona, "id_zona", "nombre");
            ViewBag.id_cocina = new SelectList(db.Cocina, "id", "nombre");
            ViewBag.user_cedula = new SelectList(db.User, "cedula", "nombre");
            return View();
        }

        // POST: Restaurantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nit,nombre,direccion,slogan,puntuacion,tenedor,fecha,user_cedula,zona,id_cocina")] Restaurantes restaurantes)
        {
            if (ModelState.IsValid)
            {
                restaurantes.fecha = DateTime.Now;
                db.Restaurantes.Add(restaurantes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.nit = new SelectList(db.Imegenes, "nit", "logo", restaurantes.nit);
            ViewBag.zona = new SelectList(db.Zona, "id_zona", "nombre", restaurantes.zona);
            ViewBag.id_cocina = new SelectList(db.Cocina, "id", "nombre", restaurantes.id_cocina);
            ViewBag.user_cedula = new SelectList(db.User, "cedula", "nombre", restaurantes.user_cedula);
            return View(restaurantes);
        }

        // GET: Restaurantes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantes restaurantes = await db.Restaurantes.FindAsync(id);
            if (restaurantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.nit = new SelectList(db.Imegenes, "nit", "logo", restaurantes.nit);
            ViewBag.zona = new SelectList(db.Zona, "id_zona", "nombre", restaurantes.zona);
            ViewBag.id_cocina = new SelectList(db.Cocina, "id", "nombre", restaurantes.id_cocina);
            ViewBag.user_cedula = new SelectList(db.User, "cedula", "nombre", restaurantes.user_cedula);
            return View(restaurantes);
        }

        // POST: Restaurantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "nit,nombre,direccion,slogan,puntuacion,tenedor,fecha,user_cedula,zona,id_cocina")] Restaurantes restaurantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nit = new SelectList(db.Imegenes, "nit", "logo", restaurantes.nit);
            ViewBag.zona = new SelectList(db.Zona, "id_zona", "nombre", restaurantes.zona);
            ViewBag.id_cocina = new SelectList(db.Cocina, "id", "nombre", restaurantes.id_cocina);
            ViewBag.user_cedula = new SelectList(db.User, "cedula", "nombre", restaurantes.user_cedula);
            return View(restaurantes);
        }

        // GET: Restaurantes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantes restaurantes = await db.Restaurantes.FindAsync(id);
            if (restaurantes == null)
            {
                return HttpNotFound();
            }
            return View(restaurantes);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Restaurantes restaurantes = await db.Restaurantes.FindAsync(id);
            db.Restaurantes.Remove(restaurantes);
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
