using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.Logica.Interfaces
{
    public interface IPeliculaServicio
    {
        List<Genero> obtenerGeneros();
        List<Calificacione> obtnerClasificaciones();
        void guardarPeliculas(Pelicula p);
        Pelicula buscarPeliculas(int? id);
        List<Pelicula> listarPeliculas();
        void borrarPelicula(int id);
        void editarPelicula(Pelicula p, int id);
    }
}
