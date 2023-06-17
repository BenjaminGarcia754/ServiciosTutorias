using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class SolucionPOJO
    {
        public int idSolucion { get; set; }

        public int idProblematica { get; set; }

        public int idAcademico { get; set; }

        public int idTutorado { get; set; }

        public string comentarios { get; set; }

        public string fechaSolucion { get; set; }
    }
}