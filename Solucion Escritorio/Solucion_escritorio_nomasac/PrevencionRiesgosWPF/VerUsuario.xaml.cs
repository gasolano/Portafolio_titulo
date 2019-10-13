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
using PrevencionRiesgos.Negocio;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace PrevencionRiesgosWPF
{
    /// <summary>
    /// Lógica de interacción para VerUsuarioWindows.xaml
    /// </summary>
    public partial class VerUsuario
    {

        Usuario uv = new Usuario().UVisualizar;
        Usuario U1 = new Usuario().ULogueado;

        public VerUsuario()
        {
            InitializeComponent();

            lblTitulo.Content = string.Format("Usuario RUT {0}", uv.Rut);
            lblNombre.Content = string.Format("Nombres {0}", uv.Nombres);
            lblap1.Content = string.Format("Apellido paterno : {0}", uv.ApellidoP);
            lblTipoUsuario.Content = string.Format("Apellido MAterno : {0}", uv.ApellidoM);
            lblPassword.Content = string.Format("Password : {0}", uv.Pass);
            lblCorreo.Content = string.Format("Correo : {0}", uv.Correo);
            lblTelefono.Content = string.Format("Telefono : {0}", uv.Telefono);
            lblMoroso.Content = string.Format("Moroso : {0}", uv.Moroso);
            lblDeBaja.Content = string.Format("De Baja : {0}", uv.DarBaja);
        }

        private void btnDarBaja_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
          
        }


    }
}
