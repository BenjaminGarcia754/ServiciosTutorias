﻿using System;
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
using FrontEndProyectoTutorias.Views;

namespace FrontEndProyectoTutorias.Views
{
    /// <summary>
    /// Lógica de interacción para MenuTutor.xaml
    /// </summary>
    public partial class MenuTutor : Window
    {
        public MenuTutor()
        {
            InitializeComponent();
        }

        private void Button_Regresar(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Registrar_Horario_Tutoria(object sender, RoutedEventArgs e)
        {
            AdministrarHorariosTutoria horariosTutoria = new AdministrarHorariosTutoria();
            horariosTutoria.Show();
            this.Close();
        }
    }
}
