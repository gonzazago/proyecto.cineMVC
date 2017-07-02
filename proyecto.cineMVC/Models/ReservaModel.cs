using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class ReservaModel
    {

        public int IdReserva { get; set; }

        [Required]
        public int IdSede { get; set; }

        [Required]
        public int IdVersion { get; set; }

        [Required]
        public int IdPelicula { get; set; }

        [Required]
        public System.DateTime FechaHoraInicio { get; set; }

        [Required(ErrorMessage = "Debe ingresar su Email")]
        [EmailAddress(ErrorMessage = "Email incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de documento")]
        public int IdTipoDocumento { get; set; }

        [Required(ErrorMessage = "Debe ingresar su numero de documento")]
        public string NumeroDocumento { get; set; }

        [Required]
        [Range(1, 10,
        ErrorMessage = "No puedes reservar mas de 10 entradas a la vez")]
        public int CantidadEntradas { get; set; }
        
        public System.DateTime FechaCarga { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual TiposDocumento TiposDocumento { get; set; }
        public virtual Versione Versione { get; set; }
    }
}