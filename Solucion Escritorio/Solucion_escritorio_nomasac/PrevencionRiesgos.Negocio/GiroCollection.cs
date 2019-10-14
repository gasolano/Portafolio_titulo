using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class GiroCollection
    {
        public static List<Giro> Deserializar(string xml)
        {
            return (List<Giro>)CommonBC.Deserializar<List<Giro>>(xml);
        }
    }
}
