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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using PrevencionRiesgos.Negocio;

namespace PrevencionWPFMetr
{
    /// <summary>
    /// Lógica de interacción para menu.xaml
    /// </summary>
    public partial class menu : MetroWindow
    {
        public menu()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            flyPerfil.Header = "PERFIL ADMIN";
            flyPerfil.IsOpen = true;
            lblTipo.Content = string.Format("{0} {1}", new Usuario().ULogueado.Nombres, new Usuario().ULogueado.ApellidoP);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void usuarios_Click(object sender, RoutedEventArgs e)
        {
            UsuariosWindow usu = new UsuariosWindow();
            usu.Show();
        }
    }
}
