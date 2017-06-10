using proyecto.Cine.Logica.Interfaces;
using proyecto.Cine.Logica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.DAL.Repositorio
{
    public class UsuarioDALImple : IUsuariosServicios

    {
        CineConexion ctx = new CineConexion();

        public bool verificarUsuario(Usuario u)
        {

            var usuario = from Usuario in ctx.Usuarios
                          where Usuario.NombreUsuario == u.NombreUsuario &&
                                Usuario.Password == u.Password
                          select Usuario;
                         
           if(usuario.Count() == 0 || usuario.Count() > 1)
            {
                return false;
            }

            return true;
        }


    }
}
