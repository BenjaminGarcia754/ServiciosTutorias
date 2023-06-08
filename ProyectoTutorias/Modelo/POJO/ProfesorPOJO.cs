using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.POJO
{
    public class ProfesorPOJO
    {
        public int idProfesor { get; set; }
        public int idRol { get; set; }
        public string nombre { get; set; }
        public string numeroDeEmpleado { get; set; }
        public string telefono { get; set; }
    }
}