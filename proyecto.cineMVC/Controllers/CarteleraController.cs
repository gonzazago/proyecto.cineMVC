using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class CarteleraController : Controller
    {
        // GET: Cartelera
        public ActionResult Index()
        {
            var prueba = new Dictionary<String, String>();
            prueba.Add("uno", "primero");
            prueba.Add("dos", "segundo");
            return View(prueba);
        }
    }
}