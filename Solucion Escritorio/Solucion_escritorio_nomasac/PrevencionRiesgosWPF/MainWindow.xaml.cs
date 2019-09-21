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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrevencionRiesgos.Negocio;
using PrevencionRiesgosWPF;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using PrevencionRiesgosWPF.Util;

namespace PrevencionRiesgosWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Usuario U1 = UtilUsuarios.ULogueado;
        
        public MainWindow()
        {
            UtilUsuarios.HLogin = DateTime.Now;
            InitializeComponent();
            lblUsuario.Content = string.Format("{0} {1}",U1.Nombres,U1.ApellidoP);
            AgregarPagina(new Inicio());
          
        }

        

        public void AgregarPagina(UserControl control)
        {
            this.gridPanel.Children.Clear();
            this.gridPanel.Children.Add(control);
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AgregarPagina(new Inicio());
        }

        private void VerClienteEmpresa(object sender, RoutedEventArgs e)
        {
            AgregarPagina(new AdmClientes());
        }

        private void AdmUsuarios(object sender, RoutedEventArgs e)
        {
            AgregarPagina(new AdmUsuarios());
        }

        private void VisActividades(object sender, RoutedEventArgs e)
        {

        }

        private void GesValMax(object sender, RoutedEventArgs e)
        {

        }

        private void GesLlamadas(object sender, RoutedEventArgs e)
        {

        }

        private void GnrRepCli(object sender, RoutedEventArgs e)
        {

        }

        private void VerFacturas(object sender, RoutedEventArgs e)
        {

        }

        private void GnrRepGen(object sender, RoutedEventArgs e)
        {

        }

        private void GesPago(object sender, RoutedEventArgs e)
        {

        }

        private void GesPlan(object sender, RoutedEventArgs e)
        {

        }

        private void SalirAplicacion(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
