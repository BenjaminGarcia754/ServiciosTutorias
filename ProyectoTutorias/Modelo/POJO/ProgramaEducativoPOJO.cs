using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class ProgramaEducativoPOJO
    {
        public int idProgramaEducativo { get; set; }

        public int idCoordinador { get; set; }

        public int anio { get; set; }

        public string area { get; set; }

        public string carrera { get; set; }

        public string clave { get; set; }
    }
}