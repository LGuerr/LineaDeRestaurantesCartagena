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
    public class ComidasController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Comidas
        public async Task<ActionResult> Index()
        {
            var comidas = db.Comidas.Include(c => c.Categorias).Include(c => c.Foto).Include(c => c.Precios);
            return View(await comidas.ToListAsync());
        }

        // GET: Comidas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comidas comidas = await db.Comidas.FindAsync(id);
            if (comidas == null)
            {
                return HttpNotFound();
            }
            return View(comidas);
        }

        // GET: Comidas/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.Categorias, "id_categoria", "nombre");
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto");
            ViewBag.Idprecio = new SelectList(db.Precios, "id_precio", "id_precio");
            return View();
        }

        // POST: Comidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_comida,nombre,descripcion,id_categoria,Idprecio,id_foto")] Comidas comidas)
        {
            if (ModelState.IsValid)
            {
                db.Comidas.Add(comidas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.Categorias, "id_categoria", "nombre", comidas.id_categoria);
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto", comidas.id_foto);
            ViewBag.Idprecio = new SelectList(db.Precios, "id_precio", "id_precio", comidas.Idprecio);
            return View(comidas);
        }

        // GET: Comidas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comidas comidas = await db.Comidas.FindAsync(id);
            if (comidas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.Categorias, "id_categoria", "nombre", comidas.id_categoria);
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto", comidas.id_foto);
            ViewBag.Idprecio = new SelectList(db.Precios, "id_precio", "id_precio", comidas.Idprecio);
            return View(comidas);
        }

        // POST: Comidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_comida,nombre,descripcion,id_categoria,Idprecio,id_foto")] Comidas comidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comidas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.Categorias, "id_categoria", "nombre", comidas.id_categoria);
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto", comidas.id_foto);
            ViewBag.Idprecio = new SelectList(db.Precios, "id_precio", "id_precio", comidas.Idprecio);
            return View(comidas);
        }

        // GET: Comidas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comidas comidas = await db.Comidas.FindAsync(id);
            if (comidas == null)
            {
                return HttpNotFound();
            }
            return View(comidas);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comidas comidas = await db.Comidas.FindAsync(id);
            db.Comidas.Remove(comidas);
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
