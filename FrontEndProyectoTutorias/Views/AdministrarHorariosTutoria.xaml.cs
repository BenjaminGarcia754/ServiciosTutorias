using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontEndProyectoTutorias.Views
{
    /// <summary>
    /// Lógica de interacción para AdministrarHorariosTutoria.xaml
    /// </summary>
    public partial class AdministrarHorariosTutoria : Window
    {
        public List<PeriodoEscolarPOJO> listaPeriodos = new List<PeriodoEscolarPOJO>();
        public AdministrarHorariosTutoria()
        {
            InitializeComponent();
            ObtenerPeriodosEscolaresAsync();
        }

        public bool ValidarCampos(string numeroTutoria, DateTime fechaTutoria)
        {
            bool respuesta = true;
            if (numeroTutoria == null || fechaTutoria == DateTime.Now)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public int ObtenerIdPeriodo(string fechaPeriodo)
        {
            int respuesta = 0;
            foreach (var periodo in listaPeriodos)
            {
                if (periodo.descripcionFecha == fechaPeriodo)
                {
                    respuesta = periodo.idPeriodo;
                }
            }
            return respuesta;
        }
        private async void ObtenerPeriodosEscolaresAsync()
        {
            List<string> descripcionPeriodos = new List<string>();
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            if (conexionServicios != null)
            {
                PeriodoEscolarPOJO[] periodosEscolares = await conexionServicios.RecuperarPeriodosEscolaresAsync();
                foreach (var periodoArray in periodosEscolares)
                {
                    listaPeriodos.Add(periodoArray);
                    descripcionPeriodos.Add(periodoArray.descripcionFecha);
                }
                cbPeriodoEscolar.ItemsSource = descripcionPeriodos;
            }
        }

        private void Button_Regresar(object sender, RoutedEventArgs e)
        {
            MenuTutor menuTutor = new MenuTutor();
            menuTutor.Show();
            this.Close();
        }

        private async void Button_Asignar_Fecha(object sender, RoutedEventArgs e)
        {
            string numeroTutoria = cbNumeroTutoria.Text;
            DateTime fechaTutoria = cldCalendarioTutoria.DisplayDate;
            DateTime fechaEntrega;

            if (!ValidarCampos(numeroTutoria, fechaTutoria))
            {
                MessageBox.Show("Se deben seleccionar la sesion de tutoria y el periodo escolar, ademas la fecha de sesion no puede ser el dia actual", "Campos Invalidos");
            }
            else
            {
                var conexionServicios = new ServiciosProyectoTutoriasClient();
                if (conexionServicios != null)
                {
                    fechaEntrega = fechaTutoria.AddDays(3);
                    InformacionTutoriaPOJO informacionTutoria = new InformacionTutoriaPOJO();
                    informacionTutoria.fechaSesion = fechaTutoria.ToString();
                    informacionTutoria.fechaEntrega = fechaEntrega.ToString();
                    informacionTutoria.idPeriodoEscolar = ObtenerIdPeriodo(fechaTutoria.ToString());
                    bool respuesta = await conexionServicios.RegistrarFechaTutoríaAsync(informacionTutoria);
                    if (respuesta)
                    {
                        MessageBox.Show("La fecha fue registrada correctamente", "Registro Eitoso");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar la fecha de tutoria", "Registro Erroneo");
                    }
                }
                else
                {
                    MessageBox.Show("Error en la conexion", "Error en la conexion");
                }
            }
        }
    }
}
