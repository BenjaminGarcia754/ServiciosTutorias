using FrontEndProyectoTutorias.Modelo;
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
    public partial class AsignarTutorAEstudiante : Window
    {
        public IDictionary<string, int> tutoresBD = new Dictionary<string, int>();
        public List<TutoradoPOJO> tutoradosPojo = new List<TutoradoPOJO>();
        private bool validarDatos()
        {
            bool respuesta = true;
            if (dgTutorados.SelectedItem == null || cbTutores.SelectedItem == null)
            {
                respuesta = false;
            }
            return respuesta;
        }

        private async void RecuperarTutores()
        {
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            List<string> tutoresCombo = new List<string>();
            if (conexionServicios != null)
            {
                ProfesorPOJO[] profesores = await conexionServicios.RecuperarListaTutoresAsync();
                foreach (var tutoresFor in profesores)
                {
                    tutoresBD.Add(tutoresFor.nombre, tutoresFor.idProfesor);
                    tutoresCombo.Add(tutoresFor.nombre);
                }
                cbTutores.ItemsSource = tutoresCombo;
            }
        }

        private async void RecuperarTutorados()
        {
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            if (conexionServicios != null)
            {
                TutoradoPOJO[] tutorados = await conexionServicios.RecuperarTutoradosSinTutorAsync();
                foreach (var tutoradosFor in tutorados)
                {
                    tutoradosPojo.Add(tutoradosFor);
                }
            }
        }

        private List<String> llenarListaTutores(List<ProfesorPOJO> tutoresViewModel)
        {
            List<string> tutoresCombo = new List<string>();
            foreach (var tutorFor in tutoresViewModel)
            {
                string nombreTutor = tutorFor.nombre;
                tutoresCombo.Add(nombreTutor);
            }

            return tutoresCombo;
        }

        public AsignarTutorAEstudiante()
        {
            InitializeComponent();
            RecuperarTutores();
            RecuperarTutorados();
            EstudianteViewModel modeloTutorado = new EstudianteViewModel();
            dgTutorados.ItemsSource = modeloTutorado.tutoradosBD;

            
        }

        private async void Button_Asignar_Tutorado(object sender, RoutedEventArgs e)
        {
            if (validarDatos())
            {
                TutoradoPOJO estudiante = (TutoradoPOJO)dgTutorados.SelectedItem;
                foreach (var tutoradoFor in tutoradosPojo)
                {
                    if (tutoradoFor.matricula == estudiante.matricula)
                    {
                        int tutor = tutoresBD[cbTutores.Text];
                        tutoradoFor.tutorAcademico = tutor;
                        var conexionServicios = new ServiciosProyectoTutoriasClient();
                        if (conexionServicios != null)
                        {
                            bool respuesta = await conexionServicios.EditarEstudianteAsync(tutoradoFor);
                            if (respuesta)
                            {
                                MessageBox.Show("Tutor Asignado Correctamente", "Cambios Exitosos");
                                EstudianteViewModel modeloTutorado = new EstudianteViewModel();
                                dgTutorados.ItemsSource = modeloTutorado.tutoradosBD;

                            }
                            else
                            {
                                MessageBox.Show("El tutor no pudo ser asignado", "Error");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Porfavor selecciona todos los datos", "Datos Invalidos");
            }
        }
    }
}
