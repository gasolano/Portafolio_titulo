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
    public partial class EmpresasWindow : MetroWindow
    {
        private Dictionary<decimal, Region> Regiones { get; set; }
        public Dictionary<decimal, Ciudad> Ciudades { get; set; }
        public Dictionary<decimal, Comuna> Comunas { get; set; }

        public EmpresasWindow()
        {
            Regiones = new  Dictionary<decimal, Region>();
            Ciudades = new Dictionary<decimal, Ciudad>();
            Comunas = new Dictionary<decimal, Comuna>();

            InitializeComponent();
            CargarControles();
            CargarDg();
            LimpiarControles();
        }
        private void LimpiarControles()
        {
            txtCorreo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtRut.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }
        private void CargarControles()
        {
            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();
            Regiones = RegionCollection.Deserializar(proxy.ReadRegionCiudadComunaCollection()).ToDictionary(x => x.IdRegion, x => x);
            var giros = GiroCollection.Deserializar(proxy.ReadGiroCollection());
            proxy.Close();

            cbRegion.DisplayMemberPath = "Nombre";
            cbRegion.SelectedValuePath = "IdRegion";

            cbCiudad.DisplayMemberPath = "Nombre";
            cbCiudad.SelectedValuePath = "IdCiudad";

            cbComuna.DisplayMemberPath = "Nombre";
            cbComuna.SelectedValuePath = "IdComuna";

            CargarComboRegion(Regiones.First().Key);


            cbGiro.DisplayMemberPath = "Nombre";
            cbGiro.SelectedValuePath = "IdGiro";
            cbGiro.ItemsSource = giros;
            cbGiro.SelectedValue = giros.First().IdGiro;
            cbGiro.Items.Refresh();
        }

        private void CargarComboRegion(decimal idSeleccionado)
        {
            if (Regiones.Count > 0)
            {
                Region regionSeleccionada = Regiones[idSeleccionado];
                cbRegion.ItemsSource = Regiones.Values.ToList();
                cbRegion.SelectedValue = regionSeleccionada.IdRegion;
                cbRegion.Items.Refresh();
                if (regionSeleccionada.Ciudades.Count > 0)
                {
                    var ciudadSeleccionada = regionSeleccionada.Ciudades.First();
                    Ciudades = regionSeleccionada.Ciudades.ToDictionary(x => x.IdCiudad, x => x);
                    CargarComboCiudad(ciudadSeleccionada.IdCiudad);
                    if (ciudadSeleccionada.Comunas.Count > 0)
                    {
                        var comunaSeleccionada = ciudadSeleccionada.Comunas.First();
                        Comunas = ciudadSeleccionada.Comunas.ToDictionary(x => x.IdComuna, x => x);
                        CargarComboComuna(comunaSeleccionada.IdComuna);
                    }
                }
            }
        }
        private void CargarComboCiudad(decimal idSeleccion)
        {
            cbCiudad.ItemsSource = Ciudades.Values.ToList();
            cbCiudad.SelectedValue = idSeleccion;
            cbCiudad.Items.Refresh();
        }
        private void CargarComboComuna(decimal idSeleccion)
        {
            cbComuna.ItemsSource = Comunas.Values.ToList();
            cbComuna.SelectedValue = idSeleccion;
            cbComuna.Items.Refresh();
        }

        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var regionSeleccionada = cbRegion.SelectedItem as Region;
            Ciudades = regionSeleccionada.Ciudades.ToDictionary(x => x.IdCiudad, x => x);
            var ciudadSeleccionada = Ciudades.First().Value;
            Comunas = ciudadSeleccionada.Comunas.ToDictionary(x => x.IdComuna, x => x);
            var comunaSeleccionada = Comunas.First().Value;

            CargarComboCiudad(ciudadSeleccionada.IdCiudad);
            CargarComboComuna(comunaSeleccionada.IdComuna);
        }
        private void cbCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ciudadSeleccionada = cbCiudad.SelectedItem as Ciudad;
            Comunas = ciudadSeleccionada.Comunas.ToDictionary(x => x.IdComuna, x => x);
            var comunaSeleccionada = Comunas.First().Value;
            CargarComboComuna(comunaSeleccionada.IdComuna);
        }
        


        private void CargarDg()
        {



            //PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            //List<Usuario> lu = UsuarioCollection.Deserializar(proxy.ReadUsuariosCollection());
            //List<TipoUsuario> ltu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            //List<ClienteEmpresa> lce = ClienteEmpresaCollection.Deserializar(proxy.ReadClienteEmpresa());

            //proxy.Close();

            //foreach (var item in lu)
            //{
            //    item.Tipo_Usuario = ltu.First(tu => tu.IdTipo == item.IdTipo).Nombre;

            //    try
            //    {
            //        item.Empresa = lce.First(ce => ce.Rut == item.RutEmpresa).Nombre;
            //    }
            //    catch (Exception)
            //    {

            //        item.Empresa = string.Empty;
            //    }



            //}
            //List<IDGUsuario> ld = new UsuarioCollection().ListaDesplegable(lu).OrderBy(usu => usu.Rut).ToList();



            //dgUsuarios.ItemsSource = ld;
            //dgUsuarios.Items.Refresh();

        }
        private void CargarDgCat()
        {

            //int IdTipo = (int)cbTipBusc.SelectedValue;

            //PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            //List<Usuario> lu = UsuarioCollection.Deserializar(proxy.ReadUsuariosCollection());
            //lu = lu.Where(u => u.IdTipo == IdTipo).ToList();
            //List<TipoUsuario> ltu = TipoUsuarioCollection.Deserializar(proxy.ReadTipoUsuario());
            //List<ClienteEmpresa> lce = ClienteEmpresaCollection.Deserializar(proxy.ReadClienteEmpresa());

            //proxy.Close();

            //foreach (var item in lu)
            //{
            //    item.Tipo_Usuario = ltu.First(tu => tu.IdTipo == item.IdTipo).Nombre;

            //    try
            //    {
            //        item.Empresa = lce.First(ce => ce.Rut == item.RutEmpresa).Nombre;
            //    }
            //    catch (Exception)
            //    {

            //        item.Empresa = string.Empty;
            //    }



            //}
            //List<IDGUsuario> ld = new UsuarioCollection().ListaDesplegable(lu).OrderBy(usu => usu.Rut).ToList();



            //dgUsuarios.ItemsSource = ld;
            //dgUsuarios.Items.Refresh();

        }
        private void CargarDgRut()
        {

        }
        private async void Tile_Click(object sender, RoutedEventArgs e)
        {
            ClienteEmpresa nuevoCliente = new ClienteEmpresa()
            {
                IdGiro = (decimal)cbGiro.SelectedValue,
                IdComuna = (decimal)cbComuna.SelectedValue,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text,
                Nombre = txtNombre.Text,
                Rut = txtRut.Text,
                Telefono = txtTelefono.Text
            };
            string xml = nuevoCliente.Serializar();


            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();
            bool valido = proxy.CreateClienteEmpresa(xml);
            proxy.Close();


            if (valido)
            {
                await this.ShowMessageAsync("Exito", "Cliente registrado correctamente.");
                LimpiarControles();
            }
            else
            {
                await this.ShowMessageAsync("Error", "No se creo el cliente, revise los datos.");
            }
        }


        private void TCMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CargarDg();
        }


    }
}

