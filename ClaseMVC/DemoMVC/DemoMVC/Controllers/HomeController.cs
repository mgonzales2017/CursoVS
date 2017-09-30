using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {

        PhotoContext contexto = new PhotoContext();

        public ActionResult PhotoLista()
        {
            return View(contexto.Photos.ToList());
        }

        public ActionResult PhotoDemo() {
            Photo photo = new Photo
            {
                CreateDate = DateTime.Now,
                Description = "Mi Foto Personal",
                PhotoID = 1,
                Title = "Mi Foto",
                UserName = "Martin"
            };
            return View(photo);
        }

        public ActionResult Index()
        {
            return View();
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
    }
}