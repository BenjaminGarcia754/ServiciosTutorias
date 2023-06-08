using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public class InformacionTutoriaDAO
    {
        public static List<InformacionTutoriaPOJO> RecuperarListaTutorias()
        {
            List<InformacionTutoriaPOJO> infoTutoriasPojo = new List<InformacionTutoriaPOJO>();
            InformacionTutoriaPOJO infoTutoria = new InformacionTutoriaPOJO();
            var conexionBD = Conexion.GenerarConexion();
            var tutoriasRecuperadas = from infoTutorias in conexionBD.InformacionTutoria
                                      select infoTutorias;

            foreach (var tutoria in tutoriasRecuperadas)
            {
                infoTutoria.idInformacionTutoria = tutoria.idInformacionTutoria;
                infoTutoria.idPeriodoEscolar = tutoria.idPeriodoEscolar;
                infoTutoria.fechaEntrega = tutoria.fechaEntrega;
                infoTutoria.fechaSesion = tutoria.fechaSesion;
                infoTutoria.noSesion = tutoria.noSesion;

                infoTutoriasPojo.Add(infoTutoria);
            }

            return infoTutoriasPojo;
        }
    }
}