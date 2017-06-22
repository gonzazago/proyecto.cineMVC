using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class CarteleraDALImple : ICarteleraServicio
    {
        CineConexion ctx = new CineConexion();

        public List<Cartelera> listarCarteleraPorPelicula(int idP)
        {
            var Cartelera = from c in ctx.Carteleras
                            join p in ctx.Peliculas on c.IdPelicula equals p.IdPelicula
                            join s in ctx.Sedes on c.IdSede equals s.IdSede
                            join v in ctx.Versiones on c.IdVersion equals v.IdVersion
                            where ((c.IdPelicula == idP) && (c.FechaInicio > DateTime.Now))

                            select c;

            return Cartelera.ToList();

        }

        public List<Cartelera> listarFuncion(int idc)
        {
            var Cartelera = from c in ctx.Carteleras
                            join p in ctx.Peliculas on c.IdPelicula equals p.IdPelicula
                            join s in ctx.Sedes on c.IdSede equals s.IdSede
                            join v in ctx.Versiones on c.IdVersion equals v.IdVersion
                            where c.IdCartelera == idc
                            select c;

            return Cartelera.ToList();

        }
    }
}
