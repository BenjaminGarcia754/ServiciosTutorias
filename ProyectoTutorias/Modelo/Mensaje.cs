using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo
{
    public class Mensaje
    { 
        public bool confirmacion {  get; set; }
        public string mensaje { get; set; }
        public HorarioTutoriaPOJO horarioTutoria { get; set; }
        public InformacionTutoriaPOJO informacionTutoria { get; set; }
        public ProblematicaAcademicaPOJO problematicaAcademica { get; set; }
        public ProfesorPOJO profesor { get; set; }
        public ReporteTutoriaPOJO reporteTutoria { get; set; }
        public SolucionPOJO solucion { get; set; }
        public TipoProblematicaPOJO tipoProblematica { get; set; }
        public TutoradoPOJO tutorado { get; set; }
        public UsuarioSesionPOJO usuarioSesion { get; set; }
    }
}