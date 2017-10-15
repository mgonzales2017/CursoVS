using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoIntranet.Controllers
{
    //[Authorize(Users = "MGONZALES")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debug.WriteLine(User.Identity.Name);
            Debug.WriteLine(User.Identity.AuthenticationType);
            Debug.WriteLine(User.Identity.IsAuthenticated);
            User.IsInRole("Admin");
            System.Security.Principal.WindowsPrincipal user = User as System.Security.Principal.WindowsPrincipal;

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