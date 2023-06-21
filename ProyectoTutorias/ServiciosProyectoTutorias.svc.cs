using ProyectoTutorias.Modelo.DAO;
using ProyectoTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProyectoTutorias.Modelo.POJO;

namespace ProyectoTutorias
{
    public class ServiciosProyectoTutorias : IServiciosProyectoTutorias
    {

        //Recuperar
        public List<InformacionTutoriaPOJO> RecuperarListaTutorias()
        {
            return InformacionTutoriaDAO.RecuperarListaTutorias();
        }

        public List<ProfesorPOJO> RecuperarListaTutores()
        {
            return ProfesorDAO.RecuperarListaTutores();
        }

        public List<PeriodoEscolarPOJO> RecuperarPeriodosEscolares()
        {
            return PeriodoEscolarDAO.ObtenerPeriodosEscolares();
        }

        public List<ProgramaEducativoPOJO> ObtenerProgramaEducativo()
        {
            return ProgramaEducativoDAO.ObtenerProgramaEducativo().ToList();
        }

        //Registrar
        public bool RegistrarFechaTutoría(InformacionTutoriaPOJO tutoria)
        {
            return InformacionTutoriaDAO.RegistrarFechaTutoría(tutoria);
        }

        public bool RegistrarProfesor(ProfesorPOJO nuevoProfesor)
        {
            return ProfesorDAO.RegistrarProfesor(nuevoProfesor);
        }

        public bool RegistrarTutorado(TutoradoPOJO nuevoTutorado)
        {
            return TutoradoDAO.RegistrarTutorado(nuevoTutorado);
        }

        public bool RegistrarReporteTutoria(ReporteTutoriaPOJO nuevoReporteTutoria)
        {
            return ReporteTutoriaDAO.RegistrarReporteTutoria(nuevoReporteTutoria);
        }

        //Editar

        public bool EditarEstudiante(TutoradoPOJO tutoradoAEdtitar)
        {
            return TutoradoDAO.EditarEstudiante(tutoradoAEdtitar);
        }

        //Iniciar Sesion

        public Mensaje iniciarSesion(string username, string password)
        {
            return UsuarioSesionDAO.IniciarSesion(username, password);
        }
    }
}
