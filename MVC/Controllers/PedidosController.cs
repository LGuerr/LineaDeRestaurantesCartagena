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
    public class PedidosController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Pedidos
        public async Task<ActionResult> Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Restaurantes).Include(p => p.Servicios).Include(p => p.User);
            return View(await pedidos.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = await db.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre");
            ViewBag.id_servicio = new SelectList(db.Servicios, "id_servicio", "nombre");
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre");
            return View();
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_pedido,id_servicio,estado,fecha,iva,total,subtotal,nit,cedula")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedidos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", pedidos.nit);
            ViewBag.id_servicio = new SelectList(db.Servicios, "id_servicio", "nombre", pedidos.id_servicio);
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre", pedidos.cedula);
            return View(pedidos);
        }

        // GET: Pedidos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = await db.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", pedidos.nit);
            ViewBag.id_servicio = new SelectList(db.Servicios, "id_servicio", "nombre", pedidos.id_servicio);
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre", pedidos.cedula);
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_pedido,id_servicio,estado,fecha,iva,total,subtotal,nit,cedula")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", pedidos.nit);
            ViewBag.id_servicio = new SelectList(db.Servicios, "id_servicio", "nombre", pedidos.id_servicio);
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre", pedidos.cedula);
            return View(pedidos);
        }

        // GET: Pedidos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedidos pedidos = await db.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pedidos pedidos = await db.Pedidos.FindAsync(id);
            db.Pedidos.Remove(pedidos);
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
