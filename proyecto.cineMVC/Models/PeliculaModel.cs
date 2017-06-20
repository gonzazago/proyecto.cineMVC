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

        [Required(ErrorMessage ="Debe insertar el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe insertar la descripcion")]
        [StringLength(500)]
        public string Descripcion { get; set; }

        //[Required(ErrorMessage = "Debe Seleccionar una imagen")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar la clasificacion")]
        public int IdCalificacion { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar el genero")]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "Indicar la duracion")]
        public int Duracion { get; set; }
        
        public DateTime FechaCarga { get; set; }
    }
}