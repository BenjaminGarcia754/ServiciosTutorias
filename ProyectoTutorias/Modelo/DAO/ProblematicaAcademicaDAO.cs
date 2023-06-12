using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class ProblematicaAcademicaDAO
    {
        public static ClaseJoin obtenerInfoProblematicaAcademica(int idTutoria)
        {
            Solucion solucion = new Solucion();
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

            ClaseJoin union = new ClaseJoin();
            union._fechaSolucion = resultado.fechaSolucionTmp;
            union._idSolucion = resultado.idSolucionTmp;
            union._idAcademico = resultado.IdAcademicoTmp;
            union._idProblematica = resultado.idProblematicaTmp;
            union._idTutorado = resultado.idTutoradoTmp;
            union.descripcion = resultado.comentariosTmp;

            return union;
        }

    }
}