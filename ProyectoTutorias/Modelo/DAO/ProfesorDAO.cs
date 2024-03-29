﻿using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class ProfesorDAO
    {
        public static bool RegistrarProfesor(ProfesorPOJO nuevoProfesor)
        {
            bool respuesta;
            Profesor profesor = new Profesor();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                profesor.telefono = nuevoProfesor.telefono;
                profesor.nombre = nuevoProfesor.nombre;
                profesor.numeroDeEmpleado = nuevoProfesor.numeroDeEmpleado;
                profesor.idRol = nuevoProfesor.idRol;
                conexionBD.Profesor.InsertOnSubmit(profesor);
                conexionBD.SubmitChanges();
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }


        public static List<ProfesorPOJO> RecuperarListaTutores()
        {
            List<ProfesorPOJO> infoTutores = new List<ProfesorPOJO>();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                var tutoresRecuperados = (from tutoresQuery in conexionBD.Profesor
                                          where tutoresQuery.idRol == 3 && tutoresQuery.numeroDeEmpleado!="0000"
                                          select tutoresQuery);

                foreach (var profesor in tutoresRecuperados)
                {
                    ProfesorPOJO tutor = new ProfesorPOJO();
                    tutor.idProfesor = profesor.idProfesor;
                    tutor.nombre = profesor.nombre;
                    tutor.numeroDeEmpleado = profesor.numeroDeEmpleado;
                    tutor.telefono = profesor.telefono;
                    tutor.idRol = profesor.idRol;
                    infoTutores.Add(tutor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return infoTutores;
        }
    }
}