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
    public class CategoriasController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Categorias
        public async Task<ActionResult> Index()
        {
            var categorias = db.Categorias.Include(c => c.Foto).Include(c => c.Restaurantes);
            return View(await categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = await db.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            ViewBag.fotoid = new SelectList(db.Foto, "id_foto", "img_foto");
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre");
            return View();
        }

        // POST: Categorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_categoria,nombre,descripcion,nit,fotoid")] Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categorias);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.fotoid = new SelectList(db.Foto, "id_foto", "img_foto", categorias.fotoid);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", categorias.nit);
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = await db.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.fotoid = new SelectList(db.Foto, "id_foto", "img_foto", categorias.fotoid);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", categorias.nit);
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_categoria,nombre,descripcion,nit,fotoid")] Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fotoid = new SelectList(db.Foto, "id_foto", "img_foto", categorias.fotoid);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", categorias.nit);
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias categorias = await db.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categorias categorias = await db.Categorias.FindAsync(id);
            db.Categorias.Remove(categorias);
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
