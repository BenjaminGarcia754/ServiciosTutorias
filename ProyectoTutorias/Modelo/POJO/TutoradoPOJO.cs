using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class TutoradoPOJO
    {
        public int idTutorado { get; set; }

        public int idProgramaEducativo { get; set; }

        public int tutorAcademico { get; set; }

        public bool estaActivo { get; set; }

        public bool estaEnRiesgo { get; set; }

        public string nombre { get; set; }

        public string matricula { get; set; }

        public string telefono { get; set; }

        public int numeroCambiosTutor { get; set; }
    }
}