using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
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

        public void guardarReserva(Reserva r)
        {
            ctx.Reservas.Add(r);
            ctx.SaveChanges();
        }
    }
}
