using proyecto.Cine.DAL.Repositorio;
using proyecto.Cine.Logica.Modelo;
//using proyecto.cineMVC.Models;
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
            List<Pelicula> pel = pMng.listarPeliculas();
            return View(pel);
        }

        public ActionResult AgregarPelicula()
        {
            List<Genero> generos = pMng.obtenerGeneros();
            List<Calificacione> cal = pMng.obtnerClasificaciones();

            ViewBag.generos = generos;
            ViewBag.calificaciones = cal;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPelicula(proyecto.cineMVC.Models.PeliculaModel p)
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

        public ActionResult Reserva()
        {
            PeliculaDALImple p = new PeliculaDALImple();
            List<Pelicula> Peliculas = new List<Pelicula>();

            Peliculas = p.listarPeliculas();

            return View(Peliculas);
        }

        public ActionResult Pelicula(int id)
        {
            CarteleraDALImple c = new CarteleraDALImple();
            List<Cartelera> Cartelera = new List<Cartelera>();

            Cartelera = c.listarCarteleraPorPelicula(id);

            if (Cartelera.Count == 0) // No hay funciones disponibles para la pelicula seleccionada
            {
                return RedirectToAction("../Administrar/administrar");
            }
            else
            {
                ViewBag.NombrePelicula = Cartelera[0].Pelicula.Nombre.ToString();

                return View(Cartelera);
            }

        }

        public ActionResult ConfirmarReserva(int id)
        {
            CarteleraDALImple c = new CarteleraDALImple();
            List<Cartelera> Cartelera = new List<Cartelera>();

            Cartelera = c.listarFuncion(id);

            ViewBag.NombrePelicula = Cartelera[0].Pelicula.Nombre.ToString();

            return View(Cartelera);
        }
    }
}