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
    public class ImegenesController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Imegenes
        public async Task<ActionResult> Index()
        {
            var imegenes = db.Imegenes.Include(i => i.Restaurantes);
            return View(await imegenes.ToListAsync());
        }

        // GET: Imegenes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imegenes imegenes = await db.Imegenes.FindAsync(id);
            if (imegenes == null)
            {
                return HttpNotFound();
            }
            return View(imegenes);
        }

        // GET: Imegenes/Create
        public ActionResult Create()
        {
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre");
            return View();
        }

        // POST: Imegenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "nit,logo,foto_perfil,foto1,foto2,foto3")] Imegenes imegenes)
        {
            if (ModelState.IsValid)
            {
                db.Imegenes.Add(imegenes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", imegenes.nit);
            return View(imegenes);
        }

        // GET: Imegenes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imegenes imegenes = await db.Imegenes.FindAsync(id);
            if (imegenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", imegenes.nit);
            return View(imegenes);
        }

        // POST: Imegenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "nit,logo,foto_perfil,foto1,foto2,foto3")] Imegenes imegenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imegenes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", imegenes.nit);
            return View(imegenes);
        }

        // GET: Imegenes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imegenes imegenes = await db.Imegenes.FindAsync(id);
            if (imegenes == null)
            {
                return HttpNotFound();
            }
            return View(imegenes);
        }

        // POST: Imegenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Imegenes imegenes = await db.Imegenes.FindAsync(id);
            db.Imegenes.Remove(imegenes);
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
