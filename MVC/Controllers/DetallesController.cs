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
    public class DetallesController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Detalles
        public async Task<ActionResult> Index()
        {
            var detalles = db.Detalles.Include(d => d.Pedidos);
            return View(await detalles.ToListAsync());
        }

        // GET: Detalles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles detalles = await db.Detalles.FindAsync(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            ViewBag.id_pedido = new SelectList(db.Pedidos, "id_pedido", "estado");
            return View();
        }

        // POST: Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_detalle,id_comida,valor,cantidad,id_pedido")] Detalles detalles)
        {
            if (ModelState.IsValid)
            {
                db.Detalles.Add(detalles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_pedido = new SelectList(db.Pedidos, "id_pedido", "estado", detalles.id_pedido);
            return View(detalles);
        }

        // GET: Detalles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles detalles = await db.Detalles.FindAsync(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pedido = new SelectList(db.Pedidos, "id_pedido", "estado", detalles.id_pedido);
            return View(detalles);
        }

        // POST: Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_detalle,id_comida,valor,cantidad,id_pedido")] Detalles detalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_pedido = new SelectList(db.Pedidos, "id_pedido", "estado", detalles.id_pedido);
            return View(detalles);
        }

        // GET: Detalles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles detalles = await db.Detalles.FindAsync(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Detalles detalles = await db.Detalles.FindAsync(id);
            db.Detalles.Remove(detalles);
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
