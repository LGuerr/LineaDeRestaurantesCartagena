using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {

       
        private  DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        public ActionResult Index()
        {
            ViewBag.zonas = new SelectList(db.Zona, "id_zona", "nombre");
            ViewBag.ambiente = new SelectList(db.Ambiente, "id", "nombre");
            ViewBag.cocina = new SelectList(db.Cocina, "id", "nombre");
            return View();
        }

        private void DB_68219_gourmetEntities()
        {
            throw new NotImplementedException();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CompleteRestaurant(string term)
        {
            DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();
            var result = from r in db.Zona where r.nombre.ToLower().Contains(term) select r.nombre;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}