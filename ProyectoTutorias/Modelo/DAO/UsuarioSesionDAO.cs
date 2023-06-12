using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class UsuarioSesionDAO
    {
        public static bool IniciarSesion(string username, string password)
        {
            bool respuesta;
            var conexionBD = Conexion.GenerarConexion();
            try
            {
                UsuarioSesion usuarioBusqueda = (from usuarioQuery in conexionBD.UsuarioSesion
                                            where usuarioQuery.username == username && usuarioQuery.contraseña == password
                                            select usuarioQuery).FirstOrDefault();
                respuesta = usuarioBusqueda != null ? true : false ;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            
            return respuesta;
        }
    }
}