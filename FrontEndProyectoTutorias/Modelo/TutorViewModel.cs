using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndProyectoTutorias.Modelo
{
    internal class TutorViewModel
    {
        public IDictionary<string, int> tutoresBD = new Dictionary<string, int>();
        public List<ProfesorPOJO> profesorPOJOs = new List<ProfesorPOJO>();
        public TutorViewModel() 
        {
            solicitarInformacionTutores();
        }

        private async void solicitarInformacionTutores()
        {
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            if (conexionServicios != null)
            {
                ProfesorPOJO[] tutoresService = await conexionServicios.RecuperarListaTutoresAsync();
                foreach (var tutorObtenido in tutoresService)
                {
                    profesorPOJOs.Add(tutorObtenido);
                    tutoresBD.Add(tutorObtenido.nombre, tutorObtenido.idProfesor);
                }
            }
        }
    }
}
