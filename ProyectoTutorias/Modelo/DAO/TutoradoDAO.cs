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
            Tutorado tutoradoModelo = new Tutorado();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
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
            catch (Exception ex)
            {
                respuesta = false;
                Console.WriteLine(ex.Message);

            }
            return respuesta;
        }

        public static List<TutoradoPOJO> RecuperarTutoradosSinTutor()
        {
            List<TutoradoPOJO> tutoradosSinTutor = new List<TutoradoPOJO>();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                var tutorados = (from tutoradosQuery in conexionBD.Tutorado
                                 where tutoradosQuery.tutorAcademico == 8
                                 select tutoradosQuery);

                foreach (var tutoradoFor in tutorados)
                {
                    TutoradoPOJO tutoradoModelo = new TutoradoPOJO();
                    tutoradoModelo.idTutorado = tutoradoFor.idTutorado;
                    tutoradoModelo.idProgramaEducativo = tutoradoFor.idProgramaEducativo;
                    tutoradoModelo.tutorAcademico = tutoradoFor.tutorAcademico;
                    tutoradoModelo.estaActivo = tutoradoFor.estaActivo;
                    tutoradoModelo.estaEnRiesgo = tutoradoFor.estaEnRiesgo;
                    tutoradoModelo.nombre = tutoradoFor.nombre;
                    tutoradoModelo.matricula = tutoradoFor.matricula;
                    tutoradoModelo.telefono = tutoradoFor.telefono;
                    tutoradoModelo.numeroCambiosTutor = tutoradoFor.numeroCambiosTutor;

                    tutoradosSinTutor.Add(tutoradoModelo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return tutoradosSinTutor;
        }

        public static bool EditarEstudiante(TutoradoPOJO nuevoTutorado)
        {
            bool respuesta;
            try
            {
                var conexionBD = Conexion.GenerarConexion();
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
            catch (Exception ex)
            {
                respuesta = false;
                Console.WriteLine(ex.Message);
            }
            return respuesta;
        }
    }
}