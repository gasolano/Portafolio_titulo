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

namespace PrevencionRiesgosWPF
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {

        Usuario U1 = new Usuario().ULogueado;

        public Inicio()
        {
            InitializeComponent();
            lblBienvenida.Content = string.Format("BIENVENIDO A NO MAS ACCIDENTES");
            lblInfo.Content = string.Format("Sistema de prevencion de riesgos");
            lblHora.Content = string.Format("Inicio Sesion {0}", new Usuario().HLogin);
            
        }
    }
}
