using proyecto.Cine.DAL.Repositorio;
using proyecto.cineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.cineMVC.validadores
{
    public static class CarteleraValidador
    {
        static CarteleraDALImple cMng = new CarteleraDALImple();

        public static Boolean existeSolapamientoDeSalas(CarteleraMetadata cartelera)
        {
            List<Cine.Logica.Modelo.Cartelera> cartelerasEnLaMismaSede = cMng.obtenerCartelerasPorSedeSalaYFecha(cartelera.IdSede, cartelera.NumeroSala, cartelera.FechaInicio, cartelera.FechaFin);
            if(cartelerasEnLaMismaSede.Count() != 0)
            {
                /* Esto sirve para cuando voy a editar la cartelera. 
                 * Si existe otra cartelera donde se solapan las salas, PERO esa cartelera es la misma a la que estoy intentando actualizar,
                 * no importa que se solapen, porque la cartelera vieja se va a actualizar con la nueva
                 */
                if (cartelerasEnLaMismaSede.Count() == 1 && cartelerasEnLaMismaSede[0].IdCartelera == cartelera.IdCartelera) return false;
                //if (cartelerasEnLaMismaSede.Count() == 1) return false;


                /* Si puede existir otra cartelera con la misma sala pero agregando el solapamiento por dias, descomentar esto
                 int diasSolapados = 0;
                    foreach(var carte in cartelerasEnLaMismaSede)
                    {
                        if (cartelera.Domingo == true && carte.Domingo == true) diasSolapados++;
                        if (cartelera.Lunes == true && carte.Lunes == true) diasSolapados++;
                        if (cartelera.Martes == true && carte.Martes == true) diasSolapados++;
                        if (cartelera.Miercoles == true && carte.Miercoles == true) diasSolapados++;
                        if (cartelera.Jueves == true && carte.Jueves == true) diasSolapados++;
                        if (cartelera.Viernes == true && carte.Viernes == true) diasSolapados++;
                        if (cartelera.Sabado == true && carte.Sabado == true) diasSolapados++;
                    }
                    if(diasSolapados > 0)
                    {
                        return true
                    }
                 */

                return true;
            }
            return false;
        }

        public static Boolean existeOtraCarteleraConMismaPelicula(CarteleraMetadata cartelera)
        {
            List<Cine.Logica.Modelo.Cartelera> cartelerasConMismaPelicula = cMng.obtenerCartelerasPorPeliculaVersionYFecha(cartelera.IdSede, cartelera.IdPelicula, cartelera.IdVersion, cartelera.FechaInicio, cartelera.FechaFin);
            if(cartelerasConMismaPelicula.Count() != 0)
            {
                if (cartelerasConMismaPelicula.Count() == 1 && cartelerasConMismaPelicula[0].IdCartelera == cartelera.IdCartelera) return false;
                return true;
            }
            return false;
        }
    }
}