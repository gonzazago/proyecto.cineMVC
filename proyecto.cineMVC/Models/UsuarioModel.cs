using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage ="Debe Completar todos los campos")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debe Completar todos los campos")]
        public string Password { get; set; }
    }
}