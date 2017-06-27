using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.Logica.Interfaces
{
    public interface ICarteleraServicio
    {
        List<Cartelera> obtenerCarteleras();
        void guardarCartelera(Cartelera cartelera);
        void borrarCartelera(int idCartelera);
        void actualizarCartelera(Cartelera cartelera);
        Cartelera obtenerCarteleraPorId(int id);
        List<Cartelera> obtenerCartelerasDeUnaSede(int numeroDeSede);
        List<Cartelera> obtenerCartelerasPorSedeSalaYFecha(int idSede, int numeroDeSala, DateTime fechaInicio, DateTime fechaFin);
        List<Cartelera> obtenerCartelerasPorPeliculaVersionYFecha(int idSede, int idPelicula, int idVersion, DateTime fechaInicio, DateTime fechaFin);
    }
}
