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
    public class PreciosController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Precios
        public async Task<ActionResult> Index()
        {
            return View(await db.Precios.ToListAsync());
        }

        // GET: Precios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precios precios = await db.Precios.FindAsync(id);
            if (precios == null)
            {
                return HttpNotFound();
            }
            return View(precios);
        }

        // GET: Precios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_precio,precio,iva")] Precios precios)
        {
            if (ModelState.IsValid)
            {
                db.Precios.Add(precios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(precios);
        }

        // GET: Precios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precios precios = await db.Precios.FindAsync(id);
            if (precios == null)
            {
                return HttpNotFound();
            }
            return View(precios);
        }

        // POST: Precios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_precio,precio,iva")] Precios precios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(precios);
        }

        // GET: Precios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precios precios = await db.Precios.FindAsync(id);
            if (precios == null)
            {
                return HttpNotFound();
            }
            return View(precios);
        }

        // POST: Precios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Precios precios = await db.Precios.FindAsync(id);
            db.Precios.Remove(precios);
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
