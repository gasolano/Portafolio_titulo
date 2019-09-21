using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrevencionRiesgos.Negocio;

namespace PrevencionRiesgosWPF.Util
{
    public static class UtilUsuarios
    {
        public static Usuario ULogueado { get; set; }
        public static Usuario UVisualizar { get; set; }
        public static DateTime HLogin { get; set; }
    }
}
