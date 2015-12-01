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
    public class SalasController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Salas
        public async Task<ActionResult> Index()
        {
            var salas = db.Salas.Include(s => s.Foto).Include(s => s.Restaurantes);
            return View(await salas.ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salas salas = await db.Salas.FindAsync(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        // GET: Salas/Create
        public ActionResult Create()
        {
            ViewBag.Foto_id_foto = new SelectList(db.Foto, "id_foto", "img_foto");
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre");
            return View();
        }

        // POST: Salas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_sala,nombre,ambiente,estado,nit,Foto_id_foto")] Salas salas)
        {
            if (ModelState.IsValid)
            {
                db.Salas.Add(salas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Foto_id_foto = new SelectList(db.Foto, "id_foto", "img_foto", salas.Foto_id_foto);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", salas.nit);
            return View(salas);
        }

        // GET: Salas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salas salas = await db.Salas.FindAsync(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Foto_id_foto = new SelectList(db.Foto, "id_foto", "img_foto", salas.Foto_id_foto);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", salas.nit);
            return View(salas);
        }

        // POST: Salas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_sala,nombre,ambiente,estado,nit,Foto_id_foto")] Salas salas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Foto_id_foto = new SelectList(db.Foto, "id_foto", "img_foto", salas.Foto_id_foto);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", salas.nit);
            return View(salas);
        }

        // GET: Salas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salas salas = await db.Salas.FindAsync(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Salas salas = await db.Salas.FindAsync(id);
            db.Salas.Remove(salas);
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
