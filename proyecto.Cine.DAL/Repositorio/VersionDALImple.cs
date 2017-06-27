using proyecto.Cine.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.Cine.Logica.Modelo;

namespace proyecto.Cine.DAL.Repositorio
{
    public class VersionDALImple : IVersionServicio
    {
        CineConexion ctx = new CineConexion();

        public List<Versione> listarVersiones()
        {
            List<Versione> versiones = ctx.Versiones.ToList();
            return versiones;
        }
    }
}
