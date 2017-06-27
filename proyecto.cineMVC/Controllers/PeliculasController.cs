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
    }

    
}