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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PeliculaDALImple p = new PeliculaDALImple();
            List<Pelicula> Peliculas = new List<Pelicula>();

            Peliculas = p.listarPeliculas();

            return View(Peliculas);
            //return View();
        }
        

    }
}