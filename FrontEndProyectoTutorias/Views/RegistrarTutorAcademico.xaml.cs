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
    /// Lógica de interacción para RegistrarTutorAcademico.xaml
    /// </summary>
    public partial class RegistrarTutorAcademico : Window
    {
        public RegistrarTutorAcademico()
        {
            InitializeComponent();
        }

        private bool comprobarDatos()
        {
            Regex exreg = new Regex("^\\d{7,10}$");
            bool respuesta = true;
            if(tbNombre == null || tbNumEmpleado == null || tbTelefono == null)
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

        private void Button_Regresar(object sender, RoutedEventArgs e)
        {
            MenuCoordinador menuCoordinador = new MenuCoordinador();
            menuCoordinador.Show();
            this.Close();
        }

        private async void Button_Registra(object sender, RoutedEventArgs e)
        {
            ProfesorPOJO profesor = new ProfesorPOJO();
            profesor.telefono = tbTelefono.Text;
            profesor.idRol = 3;
            profesor.numeroDeEmpleado = tbNumEmpleado.Text;
            profesor.nombre = tbNombre.Text;
            var conexionServicios = new ServiciosProyectoTutoriasClient();
            if (!comprobarDatos())
            {
                MessageBox.Show("Porfavor rellena toda la informacion solicitada", "Campos Inavlidos");
            }
            else
            {
                if (conexionServicios != null)
                {
                    bool respuesta = await conexionServicios.RegistrarProfesorAsync(profesor);
                    if (respuesta)
                    {
                        MessageBox.Show("Tutor Registrado correctamente", "Registro Exitoso");
                        tbTelefono.Text = "";
                        tbNumEmpleado.Text = "";
                        tbNombre.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("NO se pudo registrar al tutor", "Registro Erroneo");
                    }
                }
                else
                {
                    MessageBox.Show("Error en la conexion", "No existen servicios disponibles");
                }
            }
        }
    }
}
