using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class PeliculaDALImple : IPeliculaServicio
    {
        CineConexion ctx = new CineConexion();

        public List<Genero> obtenerGeneros()
        {
            List<Genero> gen = ctx.Generos.ToList();
            return gen;
        }

        public List<Calificacione> obtnerClasificaciones()
        {
            List<Calificacione> cal = ctx.Calificaciones.ToList();
            return cal;
        }

        public void guardarPeliculas(Pelicula p)
        {
            p.FechaCarga = DateTime.Now;
            ctx.Peliculas.Add(p);
            ctx.SaveChanges();
        }

        public Pelicula buscarPeliculas(int? id)
        {
            return ctx.Peliculas.Find(id);
        }

        public List<Pelicula> listarPeliculas()
        {
            return ctx.Peliculas.ToList();
        }

        public List<Pelicula> listarPeliculasYEstrenos()
        {
            // obtengo todas las carteleras que esten vigentes actualmente
            List<Cartelera> carteleras = ctx.Carteleras.Where(carte => carte.FechaInicio <= EntityFunctions.AddDays(DateTime.Now, 30) && carte.FechaFin >= DateTime.Now).ToList();
            List<Pelicula> peliculas = new List<Pelicula>();
            foreach(var carte in carteleras)
            {
                peliculas.Add(carte.Pelicula);
            }
            return peliculas;
        }

        public void borrarPelicula(int id)
        {
            var pelicula = ctx.Peliculas.Find(id);
            ctx.Peliculas.Remove(pelicula);
            ctx.SaveChanges();
        }
        public void editarPelicula(Pelicula p, int id)
        {
            var pedit = new Pelicula { IdPelicula = id };
            ctx.Peliculas.Attach(pedit);
            pedit.Nombre = p.Nombre;
            pedit.Descripcion = p.Descripcion;
            pedit.Imagen = p.Imagen;
            pedit.Duracion = p.Duracion;
            pedit.IdGenero = p.IdGenero;
            pedit.IdCalificacion = p.IdCalificacion;
            ctx.SaveChanges();
        }
    }
}
