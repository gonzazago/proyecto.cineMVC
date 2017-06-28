using proyecto.Cine.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class AdministrarController : Controller
    {
        ReservaDALImple resMng = new ReservaDALImple();

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
            if (Session["logeado"] == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                return RedirectToAction("login", "Usuario");
            }

            List<Cine.Logica.Modelo.Reserva> reservas = new List<Cine.Logica.Modelo.Reserva>();
            List<String> errores = new List<string>();

            if(TempData["reservas"] != null)
            {
                reservas = (List<Cine.Logica.Modelo.Reserva>) TempData["reservas"];
            }

            if(TempData["errores"] != null)
            {
                errores = (List<String>)TempData["errores"];
            }

            ViewBag.reservas = reservas;
            ViewBag.errores = errores;
            return View();
        }

        public ActionResult obtenerReportes()
        {
            String param_fechaInicio = Request["desde"];
            String param_fechaFin = Request["hasta"];

            if(String.IsNullOrEmpty(param_fechaFin) || String.IsNullOrEmpty(param_fechaInicio))
            {
                return RedirectToAction("Reportes");
            }

            List<String> errores = new List<string>();
            List<Cine.Logica.Modelo.Reserva> reservas = new List<Cine.Logica.Modelo.Reserva>();

            DateTime fechaInicio = DateTime.ParseExact(param_fechaInicio, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime fechaFin = DateTime.ParseExact(param_fechaFin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            if(fechaInicio > fechaFin)
            {
                errores.Add("La fecha de inicio no puede ser superior a la de finalizacion");
            }

            if(fechaInicio > DateTime.Now.AddDays(30) || fechaInicio < DateTime.Now.AddDays(-30))
            {
                errores.Add("La fecha de inicio no puede superar los 30 días al día de la fecha.");
            }

            if (fechaFin > DateTime.Now.AddDays(30) || fechaFin < DateTime.Now.AddDays(-30))
            {
                errores.Add("La fecha de finalizacion no puede superar los 30 días al día de la fecha.");
            }

            if(errores.Count() == 0)
            {
                reservas = resMng.obtenerReservasEntreDosFechas(fechaInicio, fechaFin);
            }

            TempData["errores"] = errores;
            TempData["reservas"] = reservas;
            return RedirectToAction("Reportes");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
    }
}