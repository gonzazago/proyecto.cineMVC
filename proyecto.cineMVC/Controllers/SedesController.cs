using proyecto.Cine.DAL.Repositorio;
using proyecto.Cine.Logica.Modelo;
using proyecto.cineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class SedesController : Controller
    {
        SedeDALImple sMng = new SedeDALImple();
        // GET: Sedes
        public ActionResult Sedes()
        {
            List <Sede> sbd = sMng.listarSedes();
            
            return View(sbd);
        }

        public ActionResult nuevaSede() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult nuevaSede([Bind(Include ="idSede,Nombre,Direccion,PrecioGeneral")]Sede s)
        {
            if (ModelState.IsValid)
            {
                sMng.agregarSede(s);
                ViewBag.Mjs = "La Sede " + s.Nombre + " ha sido agregada Correctamente";
                return RedirectToAction("Sedes", "Sedes");
            }

            TempData["Mensaje"] = "Ha ocurrido un error al insertar la sede";

            return RedirectToAction("nuevaSede", "Sede");

        }
            
    }
}