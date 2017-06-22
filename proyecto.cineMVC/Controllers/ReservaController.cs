using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto.Cine.DAL.Repositorio;
using proyecto.cineMVC.Models;
using proyecto.Cine.Logica.Modelo;

namespace proyecto.cineMVC.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guardar(ReservaModel reservaModel)
        {
            ReservaDALImple r = new ReservaDALImple();
            Reserva reserva = new Reserva();

            reserva.IdPelicula = reservaModel.IdPelicula;
            reserva.IdSede = reservaModel.IdSede;
            reserva.IdVersion = reservaModel.IdVersion;
            reserva.FechaHoraInicio = reservaModel.FechaHoraInicio;
            reserva.CantidadEntradas = reservaModel.CantidadEntradas;
            reserva.Email = reservaModel.Email;
            reserva.IdTipoDocumento = reservaModel.IdTipoDocumento;
            reserva.NumeroDocumento = reservaModel.NumeroDocumento;
            reserva.FechaCarga = DateTime.Today;

            r.guardarReserva(reserva);

            return View();
        }
    }
}