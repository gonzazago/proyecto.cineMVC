using proyecto.Cine.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class ReservaDALImple : IReservaServicio
    {
        CineConexion ctx = new CineConexion();
    }
}
