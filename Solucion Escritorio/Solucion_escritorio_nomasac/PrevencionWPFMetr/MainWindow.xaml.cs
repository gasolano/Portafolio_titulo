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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using PrevencionRiesgos.Negocio;

namespace PrevencionWPFMetr
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Tile_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();
            u.Rut = txtUser.Text;
            u.Pass = boxPassword.Password;
            string xml1 = u.Serializar();

            PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWCF.PrevencionClient();

            bool valido = proxy.ValidarUsuario(xml1);


            proxy.Close();


            if (valido)
            {

                proxy = new PrevencionRiesgosWCF.PrevencionClient();
                string xml = proxy.ReadUsuario(u.Serializar());
                proxy.Close();
                u = Usuario.Deserializar(xml);
                u.ULogueado = u;

                if (u.IdTipo == 1 || u.IdTipo == 2)
                {
                    await this.ShowMessageAsync("Alerta", "Usuario no permitido");
                    
                }
                else
                {
                    if (u.DarBaja == true)
                    {
                        await this.ShowMessageAsync("Alerta", "Usuario dado de baja");
                        return;
                    }

                    await this.ShowMessageAsync("Exito", "Tus datos son correctos");
                    menu men = new menu();
                    this.Close();
                    men.ShowDialog();
                    
                    //MainWindow mw = new MainWindow();
                    //mw.Show();
                    //this.Close();
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usuario no registrado");
                //lblInfo.Content = "Usuario no registrado";
            }
        }
    }
}
