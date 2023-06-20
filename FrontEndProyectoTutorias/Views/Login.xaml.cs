using FrontEndProyectoTutorias.Views;
using FrontEndProyectoTutorias.Views.Menu;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontEndProyectoTutorias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Iniciar_Sesion(object sender, RoutedEventArgs e)
        {
            string usuario = tbUsuario.Text;
            string contraseña = pbContraseña.Password;
            if (usuario.Length > 0 && contraseña.Length > 0)
            {
                VerificarInicioSesion(usuario, contraseña);
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña requeridos para iniciar sesión", "Datos Invalidos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void VerificarInicioSesion(string usuario, string contraseña)
        {
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            if (conexionServicios != null)
            {
                Mensaje resultado = await conexionServicios.iniciarSesionAsync(usuario, contraseña);
                if (resultado.confirmacion == true)
                {
                    MessageBox.Show("Bienvenido(a) "
                        + resultado.usuarioSesion.nombre + " al sistema.",
                        "Usuario verificado", MessageBoxButton.OK, MessageBoxImage.Information);
                    //MenuTutor menuTutor = new MenuTutor();
                    //menuTutor.Show();
                    MenuCoordinador menuCoordinador = new MenuCoordinador();
                    menuCoordinador.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "Credenciales incorrectas");
                }
            }
            else
            {
                MessageBox.Show("Error en la conexion", "No existen servicios disponibles");
            }
        }

        //TODO Metodo que seleccione que tipo de menu va a cargar
    }
}
