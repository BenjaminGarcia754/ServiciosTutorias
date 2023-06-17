using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTutorias.Modelo.DAO
{
    public static class HorarioTutoriaDAO
    {
        public static bool AsignarHorarioTutoria(HorarioTutoriaPOJO horarioARegistrar)
        {
            var conexionBD = Conexion.GenerarConexion();
            bool respuesta = false;
            HorarioTutoria horarioNuevo = new HorarioTutoria();
            try
            {
                horarioNuevo.idHorarioTutoria = horarioARegistrar.idHorarioTutoria;
                horarioNuevo.horarioTutoria1 = horarioARegistrar.horarioTutoria1;
                horarioNuevo.idTutoria = horarioARegistrar.idTutoria;
                horarioNuevo.idTutorado = horarioARegistrar.idTutorado;
                horarioNuevo.idTutor = horarioARegistrar.idTutor;
                conexionBD.HorarioTutoria.InsertOnSubmit(horarioNuevo);
                conexionBD.SubmitChanges();
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
            }

            return respuesta;
        }
    }
}