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
using PrevencionRiesgos.Negocio;
using PrevencionRiesgosWPF;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using PrevencionRiesgosWPF.Util;

namespace PrevencionRiesgosWPF
{
    /// <summary>
    /// Lógica de interacción para LoginWindows.xaml
    /// </summary>
    public partial class LoginWindows : MetroWindow
    {

        public LoginWindows()
        {
            InitializeComponent();
        }



        private void btnSesion_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();
            u.Rut = txtUser.Text;
            u.Pass = boxPassword.Password;
            string xml1 = u.Serializar();

            PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient proxy = new PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient();

            bool valido = proxy.ValidarUsuario(xml1);


            proxy.Close();


            if (valido)
            {

                proxy = new PrevencionRiesgosWPF.PrevencionRiesgosWCF.PrevencionClient();
                string xml = proxy.ReadUsuario(u.Serializar());
                proxy.Close();
                u = Usuario.Deserializar(xml);
                UtilUsuarios.ULogueado = u;
            
                if (u.IdTipo == 1 || u.IdTipo == 2)
                {
                    MessageBox.Show("Usuario no permitido", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else {
                    if (u.DarBaja == true)
                    {
                        MessageBox.Show("Usuario dado de baja", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }
            else {
                MessageBox.Show("Usuario no registrado", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
                //lblInfo.Content = "Usuario no registrado";
            }
        }





    }
}

