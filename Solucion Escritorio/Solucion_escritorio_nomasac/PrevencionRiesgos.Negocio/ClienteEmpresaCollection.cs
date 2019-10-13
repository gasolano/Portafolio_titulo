using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
   public class ClienteEmpresaCollection
    {
        public static List<ClienteEmpresa> Deserializar(string xml)
        {
            return (List<ClienteEmpresa>)CommonBC.Deserializar<List<ClienteEmpresa>>(xml);
        }
    }
}
