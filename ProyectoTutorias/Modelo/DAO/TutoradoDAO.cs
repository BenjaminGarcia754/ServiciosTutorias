using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class TutoradoDAO
    {
        public static bool RegistrarTutorado(TutoradoPOJO nuevoTutorado)
        {
            bool respuesta;
            var conexionBD = Conexion.GenerarConexion();
            Tutorado tutoradoModelo = new Tutorado();
            try
            {
                tutoradoModelo.idProgramaEducativo = nuevoTutorado.idProgramaEducativo;
                tutoradoModelo.tutorAcademico = nuevoTutorado.tutorAcademico;
                tutoradoModelo.estaActivo = nuevoTutorado.estaActivo;
                tutoradoModelo.estaEnRiesgo = nuevoTutorado.estaEnRiesgo;
                tutoradoModelo.nombre = nuevoTutorado.nombre;
                tutoradoModelo.matricula = nuevoTutorado.matricula;
                tutoradoModelo.telefono = nuevoTutorado.telefono;
                tutoradoModelo.numeroCambiosTutor = nuevoTutorado.numeroCambiosTutor;
                conexionBD.Tutorado.InsertOnSubmit(tutoradoModelo);
                conexionBD.SubmitChanges();
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}