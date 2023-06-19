using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public class TipoProblematicaDAO
    {
        public string ObtenerTipoProblematica(int opcion)
        {
            TipoProblematicaPOJO problematicaIdentificada = new TipoProblematicaPOJO();
            string tipoDeProblematica;
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                TipoProblematica tipoProblematicaTabla = (from consultaTipo in conexionBD.TipoProblematica
                                                          where consultaTipo.idTipoProblematica == opcion
                                                          select consultaTipo).FirstOrDefault();
                problematicaIdentificada.idTipoProblematica = tipoProblematicaTabla.idTipoProblematica;
                problematicaIdentificada.tipoProblematica1 = tipoProblematicaTabla.tipoProblematica1;

                tipoDeProblematica = tipoProblematicaTabla.tipoProblematica1;
                return tipoDeProblematica;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Imposible conectarse con la base de datos, por favor intente más tarde.");
                Console.WriteLine(ex.ToString());
                tipoDeProblematica = "error";
            }

            return tipoDeProblematica;
        }
    }

}