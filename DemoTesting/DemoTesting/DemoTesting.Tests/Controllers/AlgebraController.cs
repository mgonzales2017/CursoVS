using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTesting.Controllers
{
    public class AlgebraController : Controller
    {
        public ActionResult Sumar(string a, string b)
        {
            try
            {
                var digitoA = Convert.ToInt32(a);
                var digitoB = Convert.ToInt32(b);
                var resultado = digitoA + digitoB;
                return new JsonResult() { Data = resultado };
            }
            catch (NullReferenceException nullex)
            {
                throw nullex;
            }
            catch (FormatException)
            {
                var fm = new FormatException("Se intento sumar caracteres, solo se puede sumar numeros");
                return new JsonResult() { Data = fm };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = ex };
            }
        }
    }
}