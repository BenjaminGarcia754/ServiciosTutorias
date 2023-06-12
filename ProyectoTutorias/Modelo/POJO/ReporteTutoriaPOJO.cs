using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class ReporteTutoriaPOJO
    {
        public int idReporteTutoria { get; set; }

        public string descripcion { get; set; }

        public int idProgramaEducativo { get; set; }

        public int idTutoria { get; set; }

        public int idTutorado { get; set; }

        public int idTutor { get; set; }
    }
}