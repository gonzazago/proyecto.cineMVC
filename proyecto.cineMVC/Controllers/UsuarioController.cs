using proyecto.Cine.DAL;
using proyecto.Cine.Logica;
using proyecto.cineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.cineMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult agregarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarUsuario(UsuarioModel u)
        {
            Usuario us = new Usuario();
            us.NombreUsuario = u.NombreUsuario;
            us.Password = u.Password;

            UsuarioServiciosI.agregarUsuario(us);
            return RedirectToAction("Index","Home");
        }
    }
}