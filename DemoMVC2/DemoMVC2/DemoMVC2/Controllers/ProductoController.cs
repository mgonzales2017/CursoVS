using DemoMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC2.Controllers
{
    public class ProductoController : Controller
    {
        private List<Producto> Repo = new List<Producto>()
        {
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
            new Producto("random"),
        };
        public ActionResult Lista()
        {
            return View(Repo.ToList());
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Producto p) {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Crear");
            }
            else {
                return View(p);
            }
        }
    }
}