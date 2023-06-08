using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class InformacionTutoriaPOJO
    {
        public int idInformacionTutoria { get; set; }

        public int idPeriodoEscolar { get; set; }

        public int noSesion { get; set; }

        public string fechaSesion { get; set; }

        public string fechaEntrega { get; set; }
    }
}