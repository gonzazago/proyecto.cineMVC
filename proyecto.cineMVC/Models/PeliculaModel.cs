using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    
    public class PeliculaModel
    {
        public int IdPelicula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public int IdCalificacion { get; set; }
        [Required]
        public int IdGenero { get; set; }
        [Required]
        public int Duracion { get; set; }
        [Required]
        public System.DateTime FechaCarga { get; set; }
    }
}