using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class UsuarioSesionDAO
    {
        public static Mensaje IniciarSesion(string username, string password)
        {
            bool respuesta;
            Mensaje nuevoMensaje = new Mensaje();
            UsuarioSesionPOJO usuarioEncontrado = new UsuarioSesionPOJO();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                UsuarioSesion usuarioBusqueda = (from usuarioQuery in conexionBD.UsuarioSesion
                                            where usuarioQuery.username == username && usuarioQuery.contraseña == password
                                            select usuarioQuery).FirstOrDefault();
                respuesta = usuarioBusqueda != null ? true : false ;
                usuarioEncontrado.username = usuarioBusqueda.username;
                usuarioEncontrado.idRol = usuarioBusqueda.idRol;
                usuarioEncontrado.idUsuario = usuarioBusqueda.idUsuario;
                usuarioEncontrado.nombre = usuarioBusqueda.nombre;
                nuevoMensaje.mensaje = "Usuario Encontrado Satisfactoriamente";
                nuevoMensaje.confirmacion = respuesta;
                nuevoMensaje.usuarioSesion = usuarioEncontrado;
            }
            catch (Exception)
            {
                respuesta = false;
                nuevoMensaje.mensaje = "El usuario no pudo ser encontrado, porfavor verifique sus credenciales";
                nuevoMensaje.confirmacion = respuesta;
            }
            
            return nuevoMensaje;
        }
    }
}