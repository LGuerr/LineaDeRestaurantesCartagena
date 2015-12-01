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
    public class LoginsController : Controller
    {
        private DB_68219_gourmetEntities db = new DB_68219_gourmetEntities();

        // GET: Logins
        public ActionResult Inicio()
        {
            return View();
        }


        public ActionResult Login()
        {
            return RedirectToAction("","");
        }


        public ActionResult Logout()
        {
            return RedirectToAction("Inicio");
        }
    }
}
