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
    public class UsuarioController : Controller
    {
        public ActionResult login()
        {
            ViewBag.Url = Session["url"];

            return View();
        }


        [HttpPost]
        public ActionResult login(UsuarioModel u)
        {
            string url = (string)Session["Url"];
            Usuario usr = new Usuario();
            UsuarioDALImple usrMng = new UsuarioDALImple();
            usr.NombreUsuario = u.NombreUsuario;
            usr.Password = u.Password;
            if (!ModelState.IsValid || !usrMng.verificarUsuario(usr))
            {
                ViewBag.Mensaje = "Usuario / Contraseña invalida";
                return RedirectToAction("login", "Usuario");
                
            }
            Session["logeado"] = true;
            return Redirect(url);


        }
    }
}