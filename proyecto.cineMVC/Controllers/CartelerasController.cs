using proyecto.Cine.DAL.Repositorio;
using proyecto.Cine.Logica.Modelo;
using proyecto.cineMVC.Models;
using proyecto.cineMVC.validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class CartelerasController : Controller
    {
        CarteleraDALImple cMng = new CarteleraDALImple();
        SedeDALImple sMng = new SedeDALImple();
        PeliculaDALImple pMng = new PeliculaDALImple();
        VersionDALImple vMng = new VersionDALImple();

        public ActionResult Carteleras()
        {
            if (Session["logeado"] == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                return RedirectToAction("login", "Usuario");
            }
            List<Cine.Logica.Modelo.Cartelera> carteleras = cMng.obtenerCarteleras();
            List<Cine.Logica.Modelo.Pelicula> peliculas = pMng.listarPeliculas();
            List<Versione> versiones = vMng.listarVersiones();
            List<Sede> sedes = sMng.listarSedes();
            ViewBag.carteleras = carteleras;
            ViewBag.peliculas = peliculas;
            ViewBag.versiones = versiones;
            ViewBag.sedes = sedes;
            return View();
        }

        public ActionResult AgregarCartelera()
        {
            if (Session["logeado"] == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                return RedirectToAction("login", "Usuario");
            }
            List<Sede> sedes = sMng.listarSedes();
            List<Pelicula> peliculas = pMng.listarPeliculas();
            List<Versione> versiones = vMng.listarVersiones();

            List<String> errores = (List<String>)TempData["errores"];

            ViewBag.errores = errores;
            ViewBag.sedes = sedes;
            ViewBag.peliculas = peliculas;
            ViewBag.versiones = versiones;
            return View();
        }

        public ActionResult borrarCartelera(int id)
        {
            cMng.borrarCartelera(id);
            return RedirectToAction("Carteleras", "Carteleras");
        }

        public ActionResult editar(int id)
        {
            CarteleraMetadata cartelera = generarCartelera(cMng.obtenerCarteleraPorId(id));

            List<Sede> sedes = sMng.listarSedes();
            List<Pelicula> peliculas = pMng.listarPeliculas();
            List<Versione> versiones = vMng.listarVersiones();

            List<String> errores = (List<String>)TempData["errores"];

            ViewBag.errores = errores;
            ViewBag.sedes = sedes;
            ViewBag.peliculas = peliculas;
            ViewBag.versiones = versiones;
            ViewBag.fechaInicio = cartelera.FechaInicio;
            ViewBag.fechaFin = cartelera.FechaFin;
            return View(cartelera);
        }

        [HttpPost]
        public ActionResult editar(int id, CarteleraMetadata cartelera)
        {
            cartelera.IdCartelera = id;
            if (ModelState.IsValid)
            {
                List<String> errores = new List<string>();

                if(cartelera.FechaInicio > cartelera.FechaFin)
                {
                    errores.Add("La fecha de inicio no puede ser mayor a la fecha de finalizacion");
                }

                if (CarteleraValidador.existeSolapamientoDeSalas(cartelera))
                {
                    errores.Add("Existe otra cartelera con misma Sede y Sala con solapamiento de fechas");
                }

                if (CarteleraValidador.existeOtraCarteleraConMismaPelicula(cartelera))
                {
                    errores.Add("Existe otra cartelera con la misma Pelicula, Version y Sede");
                }

                if (errores.Count == 0)
                {
                    cMng.actualizarCartelera(generarCarteleraDesdeModel(cartelera));
                    return RedirectToAction("Carteleras", "Carteleras");
                }
                TempData["errores"] = errores;

            }
            return RedirectToAction("editar", new { id = cartelera.IdCartelera });
        }

        [HttpPost]
        public ActionResult AgregarCartelera(CarteleraMetadata cartelera)
        {
            if (ModelState.IsValid)
            {
                List<String> errores = new List<string>();

                if (cartelera.FechaInicio > cartelera.FechaFin)
                {
                    errores.Add("La fecha de inicio no puede ser mayor a la fecha de finalizacion");
                }

                if (CarteleraValidador.existeSolapamientoDeSalas(cartelera))
                {
                    errores.Add("Existe otra cartelera con misma Sede y Sala con solapamiento de fechas");
                }

                if (CarteleraValidador.existeOtraCarteleraConMismaPelicula(cartelera))
                {
                    errores.Add("Existe otra cartelera con la misma Pelicula, Version y Sede");
                }

                if(errores.Count == 0)
                {
                    cMng.guardarCartelera(generarCarteleraDesdeModel(cartelera));
                    return RedirectToAction("Carteleras", "Carteleras");
                }
                TempData["errores"] = errores;
                
            }
            return RedirectToAction("AgregarCartelera", "Carteleras");
        }

        private Cine.Logica.Modelo.Cartelera generarCarteleraDesdeModel(CarteleraMetadata cartelera)
        {
            Cine.Logica.Modelo.Cartelera c = new Cine.Logica.Modelo.Cartelera();
            if (cartelera.IdCartelera > 0)
            {
                c.IdCartelera = cartelera.IdCartelera;
            }
            c.IdSede = cartelera.IdSede;
            c.IdPelicula = cartelera.IdPelicula;
            c.IdVersion = cartelera.IdVersion;
            c.NumeroSala = cartelera.NumeroSala;
            c.HoraInicio = cartelera.HoraInicio;
            c.FechaInicio = cartelera.FechaInicio;
            c.FechaFin = cartelera.FechaFin;
            c.Lunes = cartelera.Lunes;
            c.Martes = cartelera.Martes;
            c.Miercoles = cartelera.Miercoles;
            c.Jueves = cartelera.Jueves;
            c.Viernes = cartelera.Viernes;
            c.Sabado = cartelera.Sabado;
            c.Domingo = cartelera.Domingo;
            return c;
        }

        private CarteleraMetadata generarCartelera(Cine.Logica.Modelo.Cartelera carte)
        {
            CarteleraMetadata c = new CarteleraMetadata();
            if (carte.IdCartelera > 0)
            {
                c.IdCartelera = carte.IdCartelera;
            }
            c.IdSede = carte.IdSede;
            c.IdPelicula = carte.IdPelicula;
            c.IdVersion = carte.IdVersion;
            c.NumeroSala = carte.NumeroSala;
            c.FechaCarga = carte.FechaCarga;
            c.HoraInicio = carte.HoraInicio;
            c.FechaInicio = carte.FechaInicio;
            c.FechaFin = carte.FechaFin;
            c.Domingo = carte.Domingo;
            c.Lunes = carte.Lunes;
            c.Martes = carte.Martes;
            c.Miercoles = carte.Miercoles;
            c.Jueves = carte.Jueves;
            c.Viernes = carte.Viernes;
            c.Sabado = carte.Sabado;
            return c;
        }
    }
}