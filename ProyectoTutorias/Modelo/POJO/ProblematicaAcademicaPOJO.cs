using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class ProblematicaAcademicaPOJO
    {
        public int idProblematica { set; get; }
        public int idReporteTutoria { set; get; }
        public string descripcion { set; get; }
        public int noIncidencias { set; get; }
        public int idTipo { set; get; }      
        
        
    }
}