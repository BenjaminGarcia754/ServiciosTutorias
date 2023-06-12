using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class UsuarioSesionPOJO
    {
        public int idUsuario { get; set; }

        public int idRol { get; set; }

        public string username { get; set; }

        public string contraseña { get; set; }

        public string nombre { get; set; }

    }
}