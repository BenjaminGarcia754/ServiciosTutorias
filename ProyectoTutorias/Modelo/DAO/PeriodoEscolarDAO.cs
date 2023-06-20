using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class PeriodoEscolarDAO
    {
        public static List<PeriodoEscolarPOJO> ObtenerPeriodosEscolares()
        {
            List<PeriodoEscolarPOJO> periodosEscolares = new List<PeriodoEscolarPOJO> ();
            try
            {
                var conexionBD = Conexion.GenerarConexion();

                var periodos = from periodosQuery in conexionBD.PeriodoEscolar
                               select periodosQuery;
                if (periodos != null)
                {
                    foreach (var periodosFor in periodos)
                    {
                        PeriodoEscolarPOJO periodoEncontrado = new PeriodoEscolarPOJO();
                        periodoEncontrado.descripcionFecha = periodosFor.descripcionFecha;
                        periodoEncontrado.idPeriodo = periodosFor.idPeriodo;
                        periodosEscolares.Add(periodoEncontrado);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return periodosEscolares.ToList();
        }
    }
}