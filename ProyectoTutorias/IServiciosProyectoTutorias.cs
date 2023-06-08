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
        [OperationContract]
        List<InformacionTutoriaPOJO> RecuperarListaTutorias();
    }
}
