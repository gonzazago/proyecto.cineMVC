using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.Models.api
{
    public class DiasYHorarioRespuesta
    {
        public List<int> Dias { get; set; }
        public int Hora { get; set; }
        public System.DateTime Hasta { get; set; }
    }
}