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
            try
            {
                var conexionBD = Conexion.GenerarConexion();
                var tutoriasRecuperadas = from infoTutorias in conexionBD.InformacionTutoria
                                          select infoTutorias;

                foreach (var tutoria in tutoriasRecuperadas)
                {
                    InformacionTutoriaPOJO infoTutoria = new InformacionTutoriaPOJO();
                    infoTutoria.idInformacionTutoria = tutoria.idInformacionTutoria;
                    infoTutoria.idPeriodoEscolar = tutoria.idPeriodoEscolar;
                    infoTutoria.fechaEntrega = tutoria.fechaEntrega;
                    infoTutoria.fechaSesion = tutoria.fechaSesion;
                    infoTutoria.noSesion = tutoria.noSesion;
                    infoTutoriasPojo.Add(infoTutoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return infoTutoriasPojo;
        }

        //A la espera de la indicacion para implementarla
        public static bool TutoriasAlcanzadas()
        {
            List<InformacionTutoriaPOJO> tutoriasRecuperadas = RecuperarListaTutorias();
            bool respuesta = tutoriasRecuperadas.Count >= 3 ? true : false;            
            return respuesta;
        }

        public static bool RegistrarFechaTutoría(InformacionTutoriaPOJO tutoria)
        {
            bool respuesta = false;
            try
            {
                InformacionTutoria infoTutoriaModelo = new InformacionTutoria();
                var conexionBD = Conexion.GenerarConexion();                
                infoTutoriaModelo.idPeriodoEscolar = tutoria.idPeriodoEscolar;
                infoTutoriaModelo.fechaEntrega = tutoria.fechaEntrega;
                infoTutoriaModelo.noSesion = tutoria.noSesion;
                infoTutoriaModelo.fechaSesion = tutoria.fechaSesion;
                conexionBD.InformacionTutoria.InsertOnSubmit(infoTutoriaModelo);
                conexionBD.SubmitChanges();                
                respuesta = true;
            }
            catch (Exception ex) 
            { 
                respuesta = false; 
                Console.WriteLine(ex.Message);
            }
            return respuesta;
        }
    }
}