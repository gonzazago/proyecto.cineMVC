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
        
        //public Sede editarSede(Sede s)
        //{
        //    ctx.

        //    return s;
        //}

        public void eliminarSede(int id)
        {
            Sede s = ctx.Sedes.Find(id);
            try { ctx.Sedes.Remove(s);
            }
            catch (UpdateException ex){
                Console.Write(ex.ToString());
            }
            
        }
        

    }
}
