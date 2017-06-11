using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Peliculas()
        {
            return View();
        }

        public ActionResult AgregarPelicula()
        {
            return View();
        }
    }
}