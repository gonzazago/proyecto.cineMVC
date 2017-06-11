using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models
{
    public class ReservaModel
    {

        public int IdReserva { get; set; }
        public int IdSede { get; set; }
        public int IdVersion { get; set; }
        public int IdPelicula { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public string Email { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int CantidadEntradas { get; set; }
        public System.DateTime FechaCarga { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual TiposDocumento TiposDocumento { get; set; }
        public virtual Versione Versione { get; set; }
    }
}