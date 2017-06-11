using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class PeliculaModel
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int IdCalificacion { get; set; }
        public int IdGenero { get; set; }
        public int Duracion { get; set; }
        public System.DateTime FechaCarga { get; set; }
    }
}