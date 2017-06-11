using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class CarteleraMetadata
    {
        public int IdCartelera { get; set; }
        public int IdSede { get; set; }
        public int IdPelicula { get; set; }
        public int HoraInicio { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public int NumeroSala { get; set; }
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