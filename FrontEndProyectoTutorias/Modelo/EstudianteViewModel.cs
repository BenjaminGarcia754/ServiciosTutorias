using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndProyectoTutorias.Modelo
{
    internal class EstudianteViewModel
    {
        public ObservableCollection<TutoradoPOJO> tutoradosBD { get; set; }
        public EstudianteViewModel()
        {
            tutoradosBD = new ObservableCollection<TutoradoPOJO>();
            solicitarInformacionTutorados();
        }

        private async void solicitarInformacionTutorados()
        {
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            if (conexionServicios != null)
            {
                TutoradoPOJO[] tutoradosService = await conexionServicios.RecuperarTutoradosSinTutorAsync();
                foreach (var tutoradoObtenido in tutoradosService)
                {
                    tutoradosBD.Add(tutoradoObtenido);
                }
            }
        }

    }
}
