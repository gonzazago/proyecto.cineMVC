using proyecto.Cine.DAL.Repositorio;
using proyecto.Cine.Logica.Modelo;
using proyecto.cineMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class PeliculasController : Controller
    {
        PeliculaDALImple pMng = new PeliculaDALImple();
        VersionDALImple vMng = new VersionDALImple();
        SedeDALImple sMng = new SedeDALImple();
        TiposDeDocumentoDALImple tdMng = new TiposDeDocumentoDALImple();
        // GET: Peliculas
        public ActionResult Peliculas()
        {
            if (Session["logeado"] == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                return RedirectToAction("login", "Usuario");
            }
            List<Pelicula> pel = pMng.listarPeliculas();
            return View(pel);
        }

        public ActionResult AgregarPelicula()
        {
            if (Session["logeado"] == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                return RedirectToAction("login", "Usuario");
            }
            List<Genero> generos = pMng.obtenerGeneros();
            List<Calificacione> cal = pMng.obtnerClasificaciones();

            ViewBag.generos = generos;
            ViewBag.calificaciones = cal;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPelicula(PeliculaModel p)
        {
            var file = Request.Files[0];

            List<Genero> generos = pMng.obtenerGeneros();
            List<Calificacione> cal = pMng.obtnerClasificaciones();
            

            ViewBag.generos = generos;
            ViewBag.calificaciones = cal;
            
            
            if (ModelState.IsValid)
            { 
                try
                {
                    if(file.ContentLength > 0)
                    {
                        Pelicula pe = new Pelicula();
                        string _filename = Path.GetFileName(file.FileName);
                        string _patch = Path.Combine(Server.MapPath("~/UploadFiles"), _filename);
                        file.SaveAs(_patch);

                        pe.Nombre = p.Nombre;
                        pe.Descripcion = p.Descripcion;
                        pe.Duracion = p.Duracion;
                        pe.IdGenero = p.IdGenero;
                        pe.IdCalificacion = p.IdCalificacion;
                        pe.Imagen = _patch;
                        pMng.guardarPeliculas(pe);
                        return RedirectToAction("Peliculas", "Peliculas");
                    }
                    
                }
                catch(Exception e)
                {
                    
                    ViewBag.Message = "Error al subir el archivo";
                }
           }
            return RedirectToAction("AgregarPelicula", "Peliculas");
        }

        public ActionResult editar(int? id)
        {
            List<Genero> generos = pMng.obtenerGeneros();
            List<Calificacione> cal = pMng.obtnerClasificaciones();
            Pelicula p = pMng.buscarPeliculas(id);
            ViewBag.generos = generos;
            ViewBag.calificaciones = cal;
            return View(p);
        }

        [HttpPost]
        public ActionResult editar(int id, Pelicula pe)
        {
            pe.IdPelicula = id;
            var file = Request.Files[0];

            List<Genero> generos = pMng.obtenerGeneros();
            List<Calificacione> cal = pMng.obtnerClasificaciones();

            ViewBag.generos = generos;
            ViewBag.calificaciones = cal;

          
            if (ModelState.IsValid)
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _filename = Path.GetFileName(file.FileName);
                        string _patch = Path.Combine(Server.MapPath("~/UploadFiles"), _filename);
                        file.SaveAs(_patch);
                        pe.Imagen = _patch;
                        pMng.editarPelicula(pe, pe.IdPelicula);
                        TempData["Mjs"] = "La Sede " + pe.Nombre + " ha sido editada Correctamente";
                        return RedirectToAction("Peliculas", "Peliculas");
                    }

                }
                catch (Exception e)
                {

                    ViewBag.Message = "Error al subir el archivo";
                }
            }
            return RedirectToAction("editar", "Peliculas");
        }

        public ActionResult reservar(int id)
        {
            Pelicula peli = pMng.buscarPeliculas(id);
            if(peli == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Versione> versiones = vMng.obtenerVersionesDeUnaPelicula(id).ToList();

            ViewBag.versiones = versiones;
            ViewBag.pelicula = peli;
            return View();
        }

        [HttpPost]
        public ActionResult reservar_pelicula(int id)
        {
            String version = Request.Form["version"];
            String sede = Request.Form["sede"];
            long fecha_aux = (long)Convert.ToDouble(Request.Form["hora_fecha"]);
            DateTime fecha = UnixTimeStampToDateTime(fecha_aux);
            String duracion = Request.Form["duracion_pelicula"];

            ReservaModel reserva = new ReservaModel();
            reserva.IdPelicula = id;
            reserva.IdSede = Int32.Parse(sede);
            reserva.IdVersion = Int32.Parse(version);
            reserva.FechaHoraInicio = fecha;
            reserva.Pelicula = pMng.buscarPeliculas(id);
            reserva.Sede = sMng.buscarSede(Int32.Parse(sede));
            reserva.Versione = vMng.obtenerVersionPorId(Int32.Parse(version));

            ViewBag.tipos_documento = tdMng.obtenerTiposDeDocumentos();

            return View(reserva);
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }

    
}