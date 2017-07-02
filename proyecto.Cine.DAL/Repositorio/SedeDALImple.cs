using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class SedeDALImple : ISedeServicios
    {
        CineConexion ctx = new CineConexion();

        public void agregarSede(Sede s)
        {
            ctx.Sedes.Add(s);
            ctx.SaveChanges();
        }

        public List<Sede> listarSedes()
        {
            List<Sede> s = ctx.Sedes.ToList();
            return s;
        }
        public Sede buscarSede(int? id)
        {
            Sede s = ctx.Sedes.Find(id);
            return s;
        }

        public void editarSede(Sede s, int id)
        {
            var sedit = new Sede { IdSede = id};
            ctx.Sedes.Attach(sedit);
            sedit.Nombre = s.Nombre;
            sedit.PrecioGeneral = s.PrecioGeneral;
            sedit.Direccion = s.Direccion;            
            ctx.SaveChanges();

        }

        public void eliminarSede(int id)
        {
            Sede s = ctx.Sedes.Find(id);
            try { ctx.Sedes.Remove(s);
            }
            catch (UpdateException ex){
                Console.Write(ex.ToString());
            }
            
        }

        public List<Sede> listarSedesPorPeliculaYVersion(int idPelicula, int idVersion)
        {
            List<Cartelera> carteleras = ctx.Carteleras.Where(car => car.IdPelicula == idPelicula && car.IdVersion == idVersion).ToList();
            HashSet<Sede> sedes = new HashSet<Sede>();
            foreach(var carte in carteleras)
            {
                sedes.Add(carte.Sede);
            }

            return sedes.ToList();
        }



    }
}
