using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class UsuarioCollection
    {

        public static List<Usuario> Deserializar(string xml)
        {
            return (List<Usuario>)CommonBC.Deserializar<List<Usuario>>(xml);
        }

    }
}
