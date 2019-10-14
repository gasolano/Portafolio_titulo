using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class Region
    {
        public decimal IdRegion { get; set; }
        public string Nombre { get; set; }
        public List<Ciudad> Ciudades { get; set; }
        public Region()
        {
            Ciudades = new List<Ciudad>();
        }
    }
}
