using FrontEndProyectoTutorias.Views.Menu;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para RegistrarTutorado.xaml
    /// </summary>
    public partial class RegistrarTutorado : Window
    {
        IDictionary<string, int> programaEducativoDiccionario = new Dictionary<string, int>();

        public RegistrarTutorado()
        {
            RecuperarProgramasEducativos();
            InitializeComponent();
        }

        private bool ComprobarDatos() 
        {
            Regex exreg = new Regex("^\\d{7,10}$");
            bool respuesta = true;
            if (tbMatricula == null || tbNombre == null || tbTelefono == null)
            {
                respuesta = false;
            }
            else if (!exreg.IsMatch(tbTelefono.Text))
            {
                respuesta = false;
                MessageBox.Show("Por favor escribe un numero de telefono valido", "Campos Inavlidos");
            }
            return respuesta;
        }

        private async void RecuperarProgramasEducativos()
        {
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            List<string> periodosCombo = new List<string>();
            if (conexionServicios != null)
            {
                ProgramaEducativoPOJO[] programas = await conexionServicios.ObtenerProgramaEducativoAsync();
                foreach (var programasFor in programas)
                {
                    programaEducativoDiccionario.Add(programasFor.carrera, programasFor.idProgramaEducativo);
                    periodosCombo.Add(programasFor.carrera);
                }
                cbProgramaEducativo.ItemsSource = periodosCombo;
            }
        }

        private void Button_Regresar(object sender, RoutedEventArgs e)
        {
            MenuCoordinador menuCoordinador = new MenuCoordinador();
            menuCoordinador.Show();
            this.Close();
        }

        private async void Button_Registrar_Estudiante(object sender, RoutedEventArgs e)
        {
            if (!ComprobarDatos())
            {
                MessageBox.Show("Porfavor rellena toda la informacion solicitada", "Campos Inavlidos");
            }
            else
            {
                TutoradoPOJO nuevoEstudiante = new TutoradoPOJO();
                nuevoEstudiante.nombre = tbNombre.Text;
                nuevoEstudiante.telefono = tbTelefono.Text;
                nuevoEstudiante.matricula = tbMatricula.Text;
                nuevoEstudiante.idProgramaEducativo = programaEducativoDiccionario[cbProgramaEducativo.Text];
                nuevoEstudiante.estaActivo = true;
                nuevoEstudiante.estaEnRiesgo = false;
                nuevoEstudiante.numeroCambiosTutor = 3;
                nuevoEstudiante.tutorAcademico = 8;

                var conexionServicios = new ServiciosProyectoTutoriasClient();
                if (conexionServicios != null)
                {
                   bool respuesta = await conexionServicios.RegistrarTutoradoAsync(nuevoEstudiante);
                    if (respuesta)
                    {
                        MessageBox.Show("Tutor Registrado correctamente", "Registro Exitoso");
                        tbMatricula.Text = "";
                        tbNombre.Text = "";
                        tbTelefono.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("NO se pudo registrar al tutor", "Registro Erroneo");
                    }
                }
            }
            
        }
    }
}
