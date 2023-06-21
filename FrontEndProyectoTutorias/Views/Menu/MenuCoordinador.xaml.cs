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

namespace FrontEndProyectoTutorias.Views.Menu
{
    /// <summary>
    /// Lógica de interacción para MenuCoordinador.xaml
    /// </summary>
    public partial class MenuCoordinador : Window
    {
        public MenuCoordinador()
        {
            InitializeComponent();
        }

        private void Button_Regresar(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Registrar_Tutor_Academico(object sender, RoutedEventArgs e)
        {
            RegistrarTutorAcademico registrarTutor = new RegistrarTutorAcademico();
            registrarTutor.Show();
            this.Close();
        }

        private void Button_Registrar_Estudiante(object sender, RoutedEventArgs e)
        {
            RegistrarTutorado registrarTutorado = new RegistrarTutorado();
            registrarTutorado.Show();
            this.Close();
        }

        private void Button_Asignar_Tutor(object sender, RoutedEventArgs e)
        {
            AsignarTutorAEstudiante asignarTutorAEstudiante = new AsignarTutorAEstudiante();
            asignarTutorAEstudiante.Show();
            this.Close();
        }
    }
}
