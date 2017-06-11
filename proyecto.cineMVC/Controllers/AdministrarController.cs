using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class AdministrarController : Controller
    {
        public ActionResult administrar()
        {
            if (Session["logeado"] == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                return RedirectToAction("login", "Usuario");
            }

            return View();

        }

        public ActionResult Peliculas()
        {
            return RedirectToAction("peliculas", "Peliculas");
        }

        public ActionResult Sedes()
        {
            return RedirectToAction("sedes", "Sedes");
        }

        public ActionResult Carteleras()
        {
            return RedirectToAction("carteleras", "Carteleras");
        }
        public ActionResult Reportes()
        {
            return RedirectToAction("reportes", "Administrar");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
    }
}