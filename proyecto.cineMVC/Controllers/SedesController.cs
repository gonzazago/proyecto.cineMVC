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
        public ActionResult nuevaSede(SedeModel s)
        {
            if (ModelState.IsValid)
            {
                Sede sede = new Sede();
                sede.Direccion = s.Direccion;
                sede.Nombre = s.Nombre;
                sede.PrecioGeneral = s.PrecioGeneral;

                sMng.agregarSede(sede);
                TempData["Mjs"] = "La Sede " + s.Nombre + " ha sido agregada Correctamente";
                return RedirectToAction("Sedes", "Sedes");
            }

            TempData["Mensaje"] = "Ha ocurrido un error al insertar la sede";

            return RedirectToAction("nuevaSede", "Sedes");

        }

        public ActionResult editar(int? id)
        {
            
            Sede s = sMng.buscarSede(id);
            
            return View(s);
        }
        [HttpPost]
        public ActionResult editar(Sede se)
        {

            if (ModelState.IsValid)
            {
                sMng.editarSede(se,se.IdSede);
                TempData["Mjs"] = "La Sede " + se.Nombre + " ha sido editada Correctamente";
                return RedirectToAction("Sedes", "Sedes");
            }

            TempData["Mensaje"] = "Ha ocurrido un error al editar la sede";

            return RedirectToAction("editar", "Sedes");


        }

    }
}