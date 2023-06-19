using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class ReporteTutoriaDAO
    {
        public static bool RegistrarReporteTutoria(ReporteTutoriaPOJO nuevoReporteTutoria)
        {
            bool respuesta;
            ReporteTutoria reporteTutoriaModelo = new ReporteTutoria();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                reporteTutoriaModelo.idTutoria = nuevoReporteTutoria.idTutoria;
                reporteTutoriaModelo.idTutor = nuevoReporteTutoria.idTutor;
                reporteTutoriaModelo.idTutorado = nuevoReporteTutoria.idTutorado;
                reporteTutoriaModelo.idProgramaEducativo = nuevoReporteTutoria.idProgramaEducativo;
                reporteTutoriaModelo.descripcion = nuevoReporteTutoria.descripcion;

                conexionBD.ReporteTutoria.InsertOnSubmit(reporteTutoriaModelo);
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