using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class CarteleraMetadata
    {
        public int IdCartelera { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una sede")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una pelicula")]
        public int IdPelicula { get; set; }

        [Required(ErrorMessage = "Debe indicar la hora de inicio")]
        [Range(1500, 2359,
        ErrorMessage = "La funcion no puede comenzar antes de las 15:00hs o despues de las 00:00hs")]
        public int HoraInicio { get; set; }

        [Required(ErrorMessage = "Debe indicar la fecha de inicio")]
        public System.DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Debe indicar la fecha en la que finaliza")]
        public System.DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Debe indicar el numero de sala")]
        public int NumeroSala { get; set; }

        [Required(ErrorMessage = "Debe indicar la version de la pelicula")]
        public int IdVersion { get; set; }

        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public System.DateTime FechaCarga { get; set; }
    }
}