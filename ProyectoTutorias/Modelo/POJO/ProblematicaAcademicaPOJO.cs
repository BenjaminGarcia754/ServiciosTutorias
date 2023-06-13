﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class ProblematicaAcademicaPOJO
    {
        public int idSolucion { set; get; }
        public int idProblematica { set; get; }
        public int idAcademico { set; get; }
        public int idTutorado { set; get; }
        public string comentarios { set; get; }
        public int idReporteTutoria { set; get; }
        public string descripcion { set; get; }

        public string fechaSolucion { set; get; }      
        
        
    }
}