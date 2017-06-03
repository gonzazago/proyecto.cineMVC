using proyecto.Cine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Cine.Logica
{
    public class UsuarioServiciosI {

        public static void agregarUsuario(Usuario u) {

            CineConexion ctx = new CineConexion();
            ctx.Usuarios.Add(u);
            ctx.SaveChanges();
        }
    }
}
