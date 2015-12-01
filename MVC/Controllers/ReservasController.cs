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
    public class ReservasController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Reservas
        public async Task<ActionResult> Index()
        {
            var reservas = db.Reservas.Include(r => r.Mesas).Include(r => r.Restaurantes).Include(r => r.Salas).Include(r => r.User);
            return View(await reservas.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = await db.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.id_mesa = new SelectList(db.Mesas, "id_mesa", "nombre");
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre");
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre");
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_reserva,id_sala,id_mesa,facha,estado,cedula,nit")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reservas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_mesa = new SelectList(db.Mesas, "id_mesa", "nombre", reservas.id_mesa);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", reservas.nit);
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre", reservas.id_sala);
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre", reservas.cedula);
            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = await db.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mesa = new SelectList(db.Mesas, "id_mesa", "nombre", reservas.id_mesa);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", reservas.nit);
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre", reservas.id_sala);
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre", reservas.cedula);
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_reserva,id_sala,id_mesa,facha,estado,cedula,nit")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_mesa = new SelectList(db.Mesas, "id_mesa", "nombre", reservas.id_mesa);
            ViewBag.nit = new SelectList(db.Restaurantes, "nit", "nombre", reservas.nit);
            ViewBag.id_sala = new SelectList(db.Salas, "id_sala", "nombre", reservas.id_sala);
            ViewBag.cedula = new SelectList(db.User, "cedula", "nombre", reservas.cedula);
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = await db.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservas reservas = await db.Reservas.FindAsync(id);
            db.Reservas.Remove(reservas);
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
