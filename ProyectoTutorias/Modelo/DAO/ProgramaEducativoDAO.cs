using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class ProgramaEducativoDAO
    {
        public static List<ProgramaEducativoPOJO> ObtenerProgramaEducativo()
        {
            List<ProgramaEducativoPOJO> programaEducativoPOJO = new List<ProgramaEducativoPOJO>();
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                var programasEducativos = from programaQuery in conexionBD.ProgramaEducativo
                                          select programaQuery;

                foreach (var programaFor in programasEducativos)
                {
                    ProgramaEducativoPOJO programaEducativo = new ProgramaEducativoPOJO();
                    programaEducativo.carrera = programaFor.carrera;
                    programaEducativo.idProgramaEducativo = programaFor.idProgramaEducativo;
                    programaEducativo.clave = programaFor.clave;
                    programaEducativo.idCoordinador = programaFor.idCoordinador;
                    programaEducativo.area = programaFor.area;
                    programaEducativo.anio = programaFor.anio;
                    programaEducativoPOJO.Add(programaEducativo);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return programaEducativoPOJO;
        }

        
        
    }
}