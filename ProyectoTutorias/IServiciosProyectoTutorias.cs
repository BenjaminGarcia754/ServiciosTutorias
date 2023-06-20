using ProyectoTutorias.Modelo;
using ProyectoTutorias.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProyectoTutorias
{
    [ServiceContract]
    public interface IServiciosProyectoTutorias
    {
        //Recuperar
        [OperationContract]
        List<InformacionTutoriaPOJO> RecuperarListaTutorias();

        [OperationContract]
        List<ProfesorPOJO> RecuperarListaTutores();

        [OperationContract]
        List<PeriodoEscolarPOJO> RecuperarPeriodosEscolares();

        //Registrar
        [OperationContract]
        bool RegistrarFechaTutoría(InformacionTutoriaPOJO tutoria);
        [OperationContract]
        bool RegistrarProfesor(ProfesorPOJO nuevoProfesor);
        [OperationContract]
        bool RegistrarTutorado(TutoradoPOJO nuevoTutorado);
        [OperationContract]
        bool RegistrarReporteTutoria(ReporteTutoriaPOJO nuevoReporteTutoria);

        //Editar
        [OperationContract]
        bool EditarEstudiante(TutoradoPOJO tutoradoAEdtitar);

        //Iniciar Sesion
        [OperationContract]
        Mensaje iniciarSesion(string username, string password);
    }
}
