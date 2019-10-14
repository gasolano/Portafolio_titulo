using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class RegionCollection
    {
        public static List<Region> Deserializar(string xml)
        {
            return (List<Region>)CommonBC.Deserializar<List<Region>>(xml);
        }
    }
}
