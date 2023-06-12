using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class ClaseJoin
    {
        public int _idSolucion { get; set; }

        public int _idProblematica { get; set; }

        public int _idAcademico { get; set; }

        public int _idTutorado { get; set; }

        public string _comentarios { get; set; }

        public string _fechaSolucion { get; set; }

        public string _fechaProblematica { get; set; }

        public string descripcion { get; set; }
    }
}