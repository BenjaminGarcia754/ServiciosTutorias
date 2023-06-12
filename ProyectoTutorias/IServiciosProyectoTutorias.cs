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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiciosProyectoTutorias
    {
        //Recuperar
        [OperationContract]
        List<InformacionTutoriaPOJO> RecuperarListaTutorias();

        [OperationContract]
        List<ProfesorPOJO> RecuperarListaTutores();

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
        bool iniciarSesion(string username, string password);
    }
}
