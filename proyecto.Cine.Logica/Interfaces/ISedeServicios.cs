using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.Logica.Interfaces
{
    public interface ISedeServicios
    {
        void agregarSede(Sede s);
        List<Sede> listarSedes();
        //void editarSede(Sede s);
        void eliminarSede(int id);

    }
}
