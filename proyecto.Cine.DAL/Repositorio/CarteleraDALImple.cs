using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class CarteleraDALImple : ICarteleraServicio
    {
        CineConexion ctx = new CineConexion();

        public void guardarCartelera(Cartelera cartelera)
        {
            cartelera.FechaCarga = DateTime.Now;
            ctx.Carteleras.Add(cartelera);
            ctx.SaveChanges();
        }

        public void borrarCartelera(int idCartelera)
        {
            Cartelera cartelera = ctx.Carteleras.Where(c => c.IdCartelera == idCartelera).FirstOrDefault();
            ctx.Carteleras.Remove(cartelera);
            ctx.SaveChanges();
        }

        public List<Cartelera> obtenerCarteleras()
        {
            List<Cartelera> carteleras = ctx.Carteleras.ToList();
            return carteleras;
        }

        public List<Cartelera> obtenerCartelerasDeUnaSede(int IdSede)
        {
            return ctx.Carteleras.Where(carte => carte.IdSede == IdSede).ToList();
        }

        public Cartelera obtenerCarteleraPorId(int id)
        {
            return ctx.Carteleras.Where(carte => carte.IdCartelera == id).FirstOrDefault();
        }

        public void actualizarCartelera(Cartelera cartelera)
        {
            Cartelera carteBase = ctx.Carteleras.Where(car => car.IdCartelera == cartelera.IdCartelera).FirstOrDefault();
            carteBase.IdSede = cartelera.IdSede;
            carteBase.IdPelicula = cartelera.IdPelicula;
            carteBase.IdVersion = cartelera.IdVersion;
            carteBase.HoraInicio = cartelera.HoraInicio;
            carteBase.FechaInicio = cartelera.FechaInicio;
            carteBase.FechaFin = cartelera.FechaFin;
            carteBase.NumeroSala = cartelera.NumeroSala;
            carteBase.FechaCarga = DateTime.Now;
            carteBase.Domingo = cartelera.Domingo;
            carteBase.Lunes = cartelera.Lunes;
            carteBase.Martes = cartelera.Martes;
            carteBase.Miercoles = cartelera.Miercoles;
            carteBase.Jueves = cartelera.Jueves;
            carteBase.Viernes = cartelera.Viernes;
            carteBase.Sabado = cartelera.Sabado;
            ctx.SaveChanges();
        }

        public List<Cartelera> obtenerCartelerasPorSedeSalaYFecha(int idSede, int numeroDeSala, DateTime fechaInicio, DateTime fechaFin)
        {
           List<Cartelera> carteleras = ctx.Carteleras.Where(
               carte => 
               (carte.IdSede == idSede && carte.NumeroSala == numeroDeSala)&&
               ( (fechaInicio >= carte.FechaInicio && fechaInicio <= carte.FechaFin) || 
                 (fechaFin >= carte.FechaInicio && fechaFin <= carte.FechaFin) ||
                 (fechaInicio <= carte.FechaInicio && fechaFin >= carte.FechaFin))).ToList();

            return carteleras;
        }

        public List<Cartelera> obtenerCartelerasPorPeliculaVersionYFecha(int idSede, int idPelicula, int idVersion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Cartelera> carteleras = ctx.Carteleras.Where(
                carte =>
                (carte.IdSede == idSede && carte.IdPelicula == idPelicula && carte.IdVersion == idVersion) &&
                ( (fechaInicio >= carte.FechaInicio && fechaInicio <= carte.FechaFin) || 
                  (fechaFin >= carte.FechaInicio && fechaFin <= carte.FechaFin) ||
                  (fechaInicio <= carte.FechaInicio && fechaFin >= carte.FechaFin))).ToList();

            return carteleras;
        }
    }
}
