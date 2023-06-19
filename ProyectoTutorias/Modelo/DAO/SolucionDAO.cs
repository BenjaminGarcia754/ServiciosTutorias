using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public class SolucionDAO
    {
        public static bool registrarSolucion(SolucionPOJO nuevaSolucionGUI)
        {
            bool respuesta;
            var conexionBD = Conexion.GenerarConexion();
            Solucion solucionNueva = new Solucion();

            try
            {
                solucionNueva.idSolucion = nuevaSolucionGUI.idSolucion;
                solucionNueva.idProblematica = nuevaSolucionGUI.idProblematica;
                solucionNueva.idAcademico = nuevaSolucionGUI.idAcademico;
                solucionNueva.idTutorado = nuevaSolucionGUI.idTutorado;
                solucionNueva.comentarios = nuevaSolucionGUI.comentarios;
                conexionBD.Solucion.InsertOnSubmit(solucionNueva);
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


        public static bool ModificarSolucion(SolucionPOJO solucionModificada)
        {
            bool respuesta;
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                Solucion solucion = (from solucionSolicitada in conexionBD.Solucion
                                     where solucionSolicitada.idProblematica == solucionModificada.idProblematica
                                     select solucionSolicitada).FirstOrDefault();

                solucion.idSolucion = solucionModificada.idSolucion;
                solucion.idProblematica = solucionModificada.idProblematica;
                solucion.idAcademico = solucionModificada.idAcademico;
                solucion.idTutorado = solucionModificada.idTutorado;
                solucion.comentarios = solucionModificada.comentarios;
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