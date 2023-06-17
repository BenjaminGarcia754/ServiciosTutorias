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



        public static bool EditarEstudiante(TutoradoPOJO nuevoTutorado)
        {
            bool respuesta;
            var conexionBD = Conexion.GenerarConexion();

            try
            {
                Tutorado tutorado = (from tutoradoQuery in conexionBD.Tutorado
                                     where tutoradoQuery.idTutorado == nuevoTutorado.idTutorado
                                     select tutoradoQuery).FirstOrDefault();

                tutorado.idProgramaEducativo = nuevoTutorado.idProgramaEducativo;
                tutorado.tutorAcademico = nuevoTutorado.tutorAcademico;
                tutorado.estaActivo = nuevoTutorado.estaActivo;
                tutorado.estaEnRiesgo = nuevoTutorado.estaEnRiesgo;
                tutorado.nombre = nuevoTutorado.nombre;
                tutorado.matricula = nuevoTutorado.matricula;
                tutorado.telefono = nuevoTutorado.telefono;
                tutorado.numeroCambiosTutor = nuevoTutorado.numeroCambiosTutor;
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