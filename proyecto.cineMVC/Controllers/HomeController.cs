using proyecto.Cine.DAL.Repositorio;
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
        PeliculaDALImple pMng = new PeliculaDALImple();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.peliculas = pMng.listarPeliculasYEstrenos();
            return View();
        }
        

    }
}