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

        public List<Reserva> obtenerReservasEntreDosFechas(DateTime desde, DateTime hasta)
        {
            return ctx.Reservas.Where(res => (res.FechaHoraInicio > desde && res.FechaHoraInicio < hasta)).ToList();
        }
    }
}
