using proyecto.Cine.DAL.Repositorio;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto.cineMVC.Models.api;

namespace proyecto.cineMVC.Controllers
{
    public class ApiController : Controller
    {
        PeliculaDALImple pMng = new PeliculaDALImple();
        VersionDALImple vMng = new VersionDALImple();
        SedeDALImple sMng = new SedeDALImple();
        CarteleraDALImple cMng = new CarteleraDALImple();
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listaDeVersiones(int id)
        {
            List<Versione> versiones = vMng.obtenerVersionesDeUnaPelicula(id).ToList();
            List<VersionesRespuesta> respuesta = new List<VersionesRespuesta>();

            foreach(var version in versiones)
            {
                VersionesRespuesta aux = new VersionesRespuesta();
                aux.IdVersion = version.IdVersion;
                aux.Nombre = version.Nombre;
                respuesta.Add(aux);
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listaDeSedesQueTienenUnaPeliculaYUnaVersion(int idPelicula, int idVersion)
        {
            List<Sede> sedes = sMng.listarSedesPorPeliculaYVersion(idPelicula, idVersion);
            List<SedesRespuesta> respuesta = new List<SedesRespuesta>();

            foreach(var sede in sedes)
            {
                SedesRespuesta aux = new SedesRespuesta();
                aux.IdSede = sede.IdSede;
                aux.Nombre = sede.Nombre;
                respuesta.Add(aux);
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        public ActionResult diasYHorarios(int idSede, int idPelicula, int idVersion)
        {
            Cartelera carte = cMng.obtenerCarteleraPorSedeYPeliculaYVersion(idSede, idPelicula, idVersion);
            List<int> dias = new List<int>();

            if (carte.Domingo) dias.Add(0);
            if (carte.Lunes) dias.Add(1);
            if (carte.Martes) dias.Add(2);
            if (carte.Miercoles) dias.Add(3);
            if (carte.Jueves) dias.Add(4);
            if (carte.Viernes) dias.Add(5);
            if (carte.Sabado) dias.Add(6);

            DiasYHorarioRespuesta respuesta = new DiasYHorarioRespuesta();
            respuesta.Dias = dias;
            respuesta.Hora = carte.HoraInicio;
            respuesta.Hasta = carte.FechaFin;

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
    }
}