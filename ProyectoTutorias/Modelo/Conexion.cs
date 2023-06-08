using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo
{
    public class Conexion
    {
        public static DataClassesProyectoTutoriasDataContext GenerarConexion()
        {
            DataClassesProyectoTutoriasDataContext conexionBd = new DataClassesProyectoTutoriasDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["EscolarUvTutoriasConnectionString"].ConnectionString);
            return conexionBd;
        }
    }
}