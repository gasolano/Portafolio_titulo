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
    /// Lógica de interacción para UsuariosWindow.xaml
    /// </summary>
    public partial class UsuariosWindow : MetroWindow
    {
        public UsuariosWindow()
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
            txtDireccion.Text = string.Empty;
            txtPass2.Text = string.Empty;
        }

        private void CargarDg()
        {

            

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            List<Usuario> lu = UsuarioCollection.Deserializar(proxy.ReadUsuariosCollection());
            List<TipoUsuario> ltu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            List<ClienteEmpresa> lce = ClienteEmpresaCollection.Deserializar(proxy.ReadClienteEmpresa());

            proxy.Close();

            foreach (var item in lu)
            {
                item.Tipo_Usuario = ltu.First(tu => tu.IdTipo == item.IdTipo).Nombre;

                try
                {
                    item.Empresa = lce.First(ce => ce.Rut == item.RutEmpresa).Nombre;
                }
                catch (Exception)
                {

                    item.Empresa = string.Empty;
                }
                    
                
                
            }
            List<IDGUsuario> ld = new UsuarioCollection().ListaDesplegable(lu).OrderBy(usu => usu.Rut).ToList();

        

            dgUsuarios.ItemsSource = ld;
            dgUsuarios.Items.Refresh();

        }
        private void CargarDgCat()
        {
            
           int IdTipo = (int)cbTipBusc.SelectedValue;

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            List<Usuario> lu = UsuarioCollection.Deserializar(proxy.ReadUsuariosCollection());
            lu = lu.Where(u => u.IdTipo == IdTipo).ToList();
            List<TipoUsuario> ltu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            List<ClienteEmpresa> lce = ClienteEmpresaCollection.Deserializar(proxy.ReadClienteEmpresa());

            proxy.Close();

            foreach (var item in lu)
            {
                item.Tipo_Usuario = ltu.First(tu => tu.IdTipo == item.IdTipo).Nombre;

                try
                {
                    item.Empresa = lce.First(ce => ce.Rut == item.RutEmpresa).Nombre;
                }
                catch (Exception)
                {

                    item.Empresa = string.Empty;
                }



            }
            List<IDGUsuario> ld = new UsuarioCollection().ListaDesplegable(lu).OrderBy(usu => usu.Rut).ToList();



            dgUsuarios.ItemsSource = ld;
            dgUsuarios.Items.Refresh();

        }
        private void CargarDgRut()
        {

        }


        private void CargarControles()
        {

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            List<TipoUsuario> lu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            List<ClienteEmpresa> lce = ClienteEmpresaCollection.Deserializar(proxy.ReadClienteEmpresa());

            proxy.Close();


            cbTipAgr.DisplayMemberPath = "Nombre";
            cbTipAgr.SelectedValuePath = "IdTipo";
            cbTipAgr.ItemsSource = lu.Where(t => t.IdTipo == 1 || t.IdTipo == 2 || t.IdTipo == 3);
            cbTipAgr.SelectedValue = "2";
            cbTipAgr.Items.Refresh();
            cbEmp.DisplayMemberPath = "Nombre";
            cbEmp.SelectedValuePath = "Rut";
            cbEmp.ItemsSource = lce;
            cbEmp.SelectedValue = "12456378-9";
            cbTipAgr.Items.Refresh();
            cbTipBusc.DisplayMemberPath = "Nombre";
            cbTipBusc.SelectedValuePath = "IdTipo";
            cbTipBusc.ItemsSource = lu.Where(t => t.IdTipo == 1 || t.IdTipo == 2 || t.IdTipo == 3); ;
            cbTipBusc.SelectedValue = "1";
            cbTipBusc.Items.Refresh();


            


        }

        private async void Tile_Click(object sender, RoutedEventArgs e)
        {
            //se recuperan valores

            string Rut = string.Empty;
            int IdTipo = 0;
            string Pass = string.Empty;
            string Nombres = string.Empty; ;
            string ApellidoP = string.Empty;
            string ApellidoM = string.Empty;
            string Correo = string.Empty;
            string Telefono = string.Empty;
            string Direccion = string.Empty;
            bool Moroso = false;
            bool DarBaja = false;
            string RutEmpresa = string.Empty;

            Rut = txtRut.Text;
            IdTipo = (int)cbTipAgr.SelectedValue;
            Pass = txtPass.Text;
            Nombres = txtNombre.Text ;
            ApellidoP = txtAplPat.Text;
            ApellidoM = txtAplMat.Text;
            Correo = txtCorreo.Text;
            Telefono = txtTelefono.Text;
            Direccion = txtDireccion.Text;
            Moroso = false;
            DarBaja = false;
            RutEmpresa = string.Format("{0}", cbEmp.SelectedValue);
            int x;
            bool numerico = int.TryParse(Telefono, out x);

            if (Rut == string.Empty || Pass == string.Empty || Nombres == string.Empty || ApellidoP == string.Empty || ApellidoM == string.Empty || Correo == string.Empty || Telefono == string.Empty || Telefono == string.Empty)
            {
                await this.ShowMessageAsync("Alerta", "Debe llenar la informacion necesaria para continuar.");
                return;

            }
            else if (!numerico)
            {
                await this.ShowMessageAsync("Alerta", "Telefono debe ser valor numerico.");
                return;
            }
            else
            {
                //se crea el Usuario
                Usuario u = new Usuario();


                u.Rut = Rut;
                
                u.IdTipo = IdTipo;
                u.Pass = Pass;
                Usuario ul = u.ULogueado;
                u.ULogueado = null;
                string xml = u.Serializar();
                u.Nombres = Nombres;
                u.ApellidoP = ApellidoP;
                u.ApellidoM = ApellidoM;
                u.Correo = Correo;
                u.Telefono = Telefono;
                u.Direccion = Direccion;
                u.Moroso = Moroso;
                u.DarBaja = DarBaja;
                if (IdTipo == 1)
                {
                    u.RutEmpresa = RutEmpresa;

                }
                else
                {
                    u.RutEmpresa = string.Empty;
                }
                xml = u.Serializar();


                PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();         
                bool valido = proxy.CreateUsuario(xml);
                proxy.Close();
                u.ULogueado = ul;
                if (valido)
                {

                    await this.ShowMessageAsync("Exito", "Usuario Registrado Correctamente.");
                   
                    //try
                    //{

                    //    Document doc = new Document();
                    //    PdfWriter.GetInstance(doc, new FileStream("C:DatosUsuario.pdf", FileMode.Create));
                    //    doc.Open();




                    //    StringBuilder sb = new StringBuilder();

                    //    sb.AppendLine("Rut: " + rut);
                    //    sb.AppendLine("Nombre: " + nombre);
                    //    sb.AppendLine("Apellido: " + apellidoP);
                    //    sb.AppendLine("Contraseña: " + pass);


                    //    iTextSharp.text.Paragraph par = new iTextSharp.text.Paragraph("" + sb);

                    //    doc.Add(par);
                    //    doc.Close();


                    //    Correo Cr = new Correo();
                    //    MailMessage mnsj = new MailMessage();

                    //    mnsj.Subject = "Registro de usuario";
                    //    mnsj.To.Add(new MailAddress(correo));
                    //    mnsj.From = new MailAddress("plio.bld17@gmail.com", "Administrador BLD");
                    //    mnsj.Attachments.Add(new Attachment("C:DatosUsuario.pdf"));
                    //    mnsj.Body = string.Format("Usted ha sido registrado exitosamente en el pañol de {0} de Duoc Uc sede {1}", u.escuela, u.sede);

                    //    Cr.MandarCorreo(mnsj);

                    //    MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!");
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.ToString());
                    //}
                }
                else
                {
                    await this.ShowMessageAsync("Error", "No Se Pudo Registrar El Usuario.");
                }
                LimpiarControles();

            }
        }

        private void cbTipAgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipAgr.SelectedValue == null)
            {
                return;
            }
            if ((int)cbTipAgr.SelectedValue == 1)
            {
                cbEmp.IsEnabled = true;
            }
            else
            {
                cbEmp.IsEnabled = false;
            }
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            CargarDg();
        }

        private void MetroTabItem_TouchEnter(object sender, TouchEventArgs e)
        {
            CargarDg();
        }

      
        private void TCMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CargarDg();
        }

        private void MetroTabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            CargarDg();
        }

        private async void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            Usuario u = (Usuario)dgUsuarios.SelectedItem;
            IDGUsuario uv = (IDGUsuario)u;
            if (u != null)
            {

                flyout.IsOpen = true;
                flyout.Header = string.Format("{0} {1}",uv.Nombres, uv.Apellidos);
                lblRut.Content = string.Format("Rut: {0}",uv.Rut);
                lblTipo.Content = string.Format("Tipo usuario: {0}",uv.Tipo_Usuario);
                lblDireccion.Content = string.Format("Direccion: {0}",uv.Direccion);
                lblTelefono.Content = string.Format("Telefono: {0}",uv.Telefono);
                lblCorreo.Content = string.Format("Correo electronico: {0}",uv.Correo);
                lblDeBaja.Content = string.Format("Usuario de baja: {0}",uv.De_Baja);
                lblMoroso.Content = string.Format("Usuario Moroso: {0}",uv.CMoroso);
            }
            else
            {
                await this.ShowMessageAsync("Alerta", "Debe seleccionar un Usuario");
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();
            List<TipoUsuario> lu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            proxy.Close();

            cbMTipoUsuario.DisplayMemberPath = "Nombre";
            cbMTipoUsuario.SelectedValuePath = "IdTipo";
            cbMTipoUsuario.ItemsSource = lu.Where(t => t.IdTipo == 1 || t.IdTipo == 2 || t.IdTipo == 3);
            cbMTipoUsuario.Items.Refresh();
            Usuario u = (Usuario)dgUsuarios.SelectedItem;
            IDGUsuario uv = (IDGUsuario)u;
            flModificar.IsOpen = true;
            flModificar.Header = string.Format("{0} {1}", uv.Nombres, uv.Apellidos);
            CargarModificar(u);



        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            CargarDgCat();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = (Usuario)dgUsuarios.SelectedItem;
            u.Nombres = txtMNombres.Text;
            u.ApellidoP = txtMApellidoP.Text;
            u.Correo = txtMCorreo.Text;
            u.Direccion = txtMDireccion.Text;
            u.ApellidoM = txtMApellidoM.Text;
            u.Telefono = txtMTelefono.Text;
            u.IdTipo = (int)cbMTipoUsuario.SelectedValue;

            string xml = u.Serializar();

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            bool valido = proxy.ModificarUsuario(xml);

           proxy.Close();

           

            if (valido)
            {

                await this.ShowMessageAsync("Exito", "Usuario Modificado Correctamente.");

             
            }
            else
            {
                await this.ShowMessageAsync("Error", "No Se Pudo Modificado El Usuario.");
            }
            CargarModificar(u);

        }

        private void CargarModificar(Usuario u)
        {
            txtMNombres.Text = u.Nombres;
            txtMApellidoP.Text = u.ApellidoP;
            txtMApellidoM.Text = u.ApellidoM;
            txtMCorreo.Text = u.Correo;
            txtMDireccion.Text = u.Direccion;
            txtMTelefono.Text = u.Telefono;
            cbMTipoUsuario.SelectedValue = string.Format("{0}", u.IdTipo);
            cbMTipoUsuario.Items.Refresh();
        }

        private async void btnBaja_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = (Usuario)dgUsuarios.SelectedItem;
            u.DarBaja = true;

            string xml = u.Serializar();

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            bool valido = proxy.ModificarUsuario(xml);

            proxy.Close();



            if (valido)
            {

                await this.ShowMessageAsync("Exito", "Usuario dado de baja Correctamente.");


            }
            else
            {
                await this.ShowMessageAsync("Error", "No Se Pudo dar de baja El Usuario.");
            }
            CargarModificar(u);
        }

        private void MetroTabItem_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            flModificar.IsOpen = true;
        }

   

        //private void MetroTabItem_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    flModificar.IsOpen = true;
        //}



        //private void MetroTabItem_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    flModificar.IsOpen = true;
        //}




        //private void MetroTabItem_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    flModificar.IsOpen = true;
        //}
    }
    }

