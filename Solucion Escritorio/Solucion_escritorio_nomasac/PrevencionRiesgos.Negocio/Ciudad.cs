using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class Ciudad
    {
        public decimal IdCiudad { get; set; }
        public string Nombre { get; set; }
        public decimal IdRegion { get; set; }
        public List<Comuna> Comunas { get; set; }
        public Ciudad()
        {
            Comunas = new List<Comuna>();
        }
    }
}
