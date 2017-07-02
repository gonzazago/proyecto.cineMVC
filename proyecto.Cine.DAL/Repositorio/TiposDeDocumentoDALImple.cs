using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class TiposDeDocumentoDALImple : ITiposDeDocumento
    {
        CineConexion ctx = new CineConexion();

        public List<TiposDocumento> obtenerTiposDeDocumentos()
        {
            return ctx.TiposDocumentos.ToList();
        }
    }
}
