using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class HorarioTutoriaPOJO
    {
        public int idHorarioTutoria { get; }
        public DateTime horarioTutoria { set; get; }
        public int idTutoria { set; get; }
        public int idTutorado { set; get; }
        public int idTutor { set; get; }

    }
}