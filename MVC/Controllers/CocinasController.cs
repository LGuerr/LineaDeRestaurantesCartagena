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
    public class CocinasController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Cocinas
        public async Task<ActionResult> Index()
        {
            return View(await db.Cocina.ToListAsync());
        }

        // GET: Cocinas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocina cocina = await db.Cocina.FindAsync(id);
            if (cocina == null)
            {
                return HttpNotFound();
            }
            return View(cocina);
        }

        // GET: Cocinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cocinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre")] Cocina cocina)
        {
            if (ModelState.IsValid)
            {
                db.Cocina.Add(cocina);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cocina);
        }

        // GET: Cocinas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocina cocina = await db.Cocina.FindAsync(id);
            if (cocina == null)
            {
                return HttpNotFound();
            }
            return View(cocina);
        }

        // POST: Cocinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre")] Cocina cocina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cocina).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cocina);
        }

        // GET: Cocinas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocina cocina = await db.Cocina.FindAsync(id);
            if (cocina == null)
            {
                return HttpNotFound();
            }
            return View(cocina);
        }

        // POST: Cocinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cocina cocina = await db.Cocina.FindAsync(id);
            db.Cocina.Remove(cocina);
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
