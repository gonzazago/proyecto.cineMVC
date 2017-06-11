using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class SedeModel
    {

        public int IdSede { get; set; }
        [Required(ErrorMessage ="El nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Debe introducir una direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar el precio/El precio debe ser mayor a Cero ")]
        [Range(1,99999)]
        public decimal PrecioGeneral { get; set; }
    }
}