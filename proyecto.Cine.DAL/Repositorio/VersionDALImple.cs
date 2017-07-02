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

        public HashSet<Versione> obtenerVersionesDeUnaPelicula(int id)
        {
            List<Cartelera> carteleras = ctx.Carteleras.Where(car => car.IdPelicula == id).ToList();
            HashSet<Versione> versiones = new HashSet<Versione>();
            foreach(var carte in carteleras)
            {
                versiones.Add(carte.Versione);
            }

            return versiones;
        }

        public Versione obtenerVersionPorId(int id)
        {
            return ctx.Versiones.Find(id);
        }
    }
}
