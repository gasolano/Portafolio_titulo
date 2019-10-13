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
using System.Net.Mail;

using System.IO;

using PrevencionRiesgos.Negocio;

namespace PrevencionRiesgosWPF
{
    /// <summary>
    /// Lógica de interacción para AdmUsuarios.xaml
    /// </summary>
    public partial class AdmUsuarios : UserControl
    {
        Usuario U1 = new Usuario().ULogueado;

        public AdmUsuarios()
        {
            InitializeComponent();
            CargarControles();
           CargarDg();
            LimpiarControles();
      
        }

        private void LimpiarControles()
        {
            txtAplMat.Text = string.Empty;
            txtAplPat.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtRut.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void CargarDg()
        {


            PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient();

            List<Usuario> lu = UsuarioCollection.Deserializar(proxy.ReadUsuariosCollection());


            proxy.Close();

            dgUsuarios.ItemsSource = lu;
            dgUsuarios.Items.Refresh();
            
        }
        private void CargarDgCat()
        {

      
        }
        private void CargarDgRut()
        {
     
        }


        private void CargarControles()
        {


            PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient();

            List<TipoUsuario> lu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            //List<ClienteEmpresa> lce = ClienteEmpresaCollection.Deserializar();

            proxy.Close();


            cbTipAgr.DisplayMemberPath = "Nombre";
            cbTipAgr.SelectedValuePath = "IdTipo";
            cbTipAgr.ItemsSource = lu.Where(t => t.IdTipo == 1 || t.IdTipo == 2 || t.IdTipo == 3);
            cbTipAgr.SelectedValue = "1";
            cbTipAgr.Items.Refresh();
            cbTipBusc.DisplayMemberPath = "Nombre";
            cbTipBusc.SelectedValuePath = "IdTipo";
            cbTipBusc.ItemsSource = lu.Where(t => t.IdTipo == 1 || t.IdTipo == 2 || t.IdTipo == 3); ;
            cbTipBusc.SelectedValue = "1";
            cbTipBusc.Items.Refresh();
           

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
           
      
        }

        private void CrearPDF()
        {
            


        }

        private void btnTipBusc_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private void btnBuscRut_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnVisualiar_Click(object sender, RoutedEventArgs e)
        {
          
            Usuario u = (Usuario)dgUsuarios.SelectedItem;
            if (u != null)
            {
                u.UVisualizar = u;
                VerUsuario vuw = new VerUsuario();
                vuw.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario", "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
          
        }




    }
}
