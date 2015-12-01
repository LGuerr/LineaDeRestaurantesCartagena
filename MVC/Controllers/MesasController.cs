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
    public class MesasController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Mesas
        public async Task<ActionResult> Index()
        {
            var mesas = db.Mesas.Include(m => m.Foto).Include(m => m.Salas);
            return View(await mesas.ToListAsync());
        }

        // GET: Mesas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesas mesas = await db.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto");
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre");
            return View();
        }

        // POST: Mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_mesa,nombre,sillas,tipo,id_sala,id_foto")] Mesas mesas)
        {
            if (ModelState.IsValid)
            {
                db.Mesas.Add(mesas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto", mesas.id_foto);
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre", mesas.id_sala);
            return View(mesas);
        }

        // GET: Mesas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesas mesas = await db.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto", mesas.id_foto);
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre", mesas.id_sala);
            return View(mesas);
        }

        // POST: Mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_mesa,nombre,sillas,tipo,id_sala,id_foto")] Mesas mesas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_foto = new SelectList(db.Foto, "id_foto", "img_foto", mesas.id_foto);
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre", mesas.id_sala);
            return View(mesas);
        }

        // GET: Mesas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesas mesas = await db.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mesas mesas = await db.Mesas.FindAsync(id);
            db.Mesas.Remove(mesas);
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
