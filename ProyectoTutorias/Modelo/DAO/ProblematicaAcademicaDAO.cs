using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public class ProblematicaAcademicaDAO
    {
        public static List<ProblematicaAcademicaPOJO> RecuperarListaProblematicas()
        {
            List<ProblematicaAcademicaPOJO> listaProblematicaAcademica = new List<ProblematicaAcademicaPOJO>();
            ProblematicaAcademicaPOJO problematicaAcademicaConsulta = new ProblematicaAcademicaPOJO();
            var conexionBD = Conexion.GenerarConexion();
            var problematicaAcademicaRespuesta = from problematicaAcademicaSolicitud in conexionBD.Problematica
                                                 select problematicaAcademicaSolicitud;

            foreach (var problematica in problematicaAcademicaRespuesta)
            {
                problematicaAcademicaConsulta.idProblematica = problematica.idProblematica;
                problematicaAcademicaConsulta.idReporteTutoria = problematica.idReporteTutoria;
                problematicaAcademicaConsulta.descripcion = problematica.descripcion;


                listaProblematicaAcademica.Add(problematicaAcademicaConsulta);
            }

            return listaProblematicaAcademica;
        }

        /*     public static ProblematicaAcademicaPOJO obtenerInfoProblematicaAcademica(int idTutoria)
             {
                 ProblematicaAcademicaPOJO respuestaProblematica = new Problematica();
                 var conexionBD = Conexion.GenerarConexion();
                 var resultado = (from infoProblematicaQuery in conexionBD.Problematica
                                  join infoSolucionQuery in conexionBD.Solucion
                                  on infoProblematicaQuery.idProblematica equals infoSolucionQuery.idProblematica
                                  where infoProblematicaQuery.idReporteTutoria == idTutoria
                                  select new
                                  {
                                      idSolucionTmp = infoSolucionQuery.idSolucion,
                                      idProblematicaTmp = infoProblematicaQuery.idProblematica,
                                      IdAcademicoTmp = infoSolucionQuery.idAcademico,
                                      idTutoradoTmp = infoSolucionQuery.idTutorado,
                                      comentariosTmp = infoProblematicaQuery.descripcion,
                                      fechaSolucionTmp = infoSolucionQuery.fechaSolucion
                                  }).FirstOrDefault();

                 ProblematicaAcademicaPOJO union = new ProblematicaAcademicaPOJO();
                 union.fechaSolucion = resultado.fechaSolucionTmp;
                 union.idSolucion = resultado.idSolucionTmp;
                 union.idAcademico = resultado.IdAcademicoTmp;
                 union.idProblematica = resultado.idProblematicaTmp;
                 union.idTutorado = resultado.idTutoradoTmp;
                 union.descripcion = resultado.comentariosTmp;

                 return union;
             }*/
        //crear método para  recuperar problemática por id, al seleccionarlo se crea el objeto de problemática

        public static bool RegistrarProblematicaAcademica(ProblematicaAcademicaPOJO nuevaProblematica)
        {
            bool respuesta;
            var conexionBD = Conexion.GenerarConexion();
            Problematica problematica = new Problematica();
            try
            {
                problematica.idProblematica = nuevaProblematica.idProblematica;
                problematica.idReporteTutoria = nuevaProblematica.idReporteTutoria;
                problematica.descripcion = nuevaProblematica.descripcion;
                problematica.noIncidencias = nuevaProblematica.noIncidencias;
                problematica.idTipo = nuevaProblematica.idTipo;
                conexionBD.Problematica.InsertOnSubmit(problematica);
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