using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrevencionRiesgos.Negocio;

namespace PrevencionRiesgos.Negocio
{
    public class TipoUsuarioCollection
    {


        public static List<TipoUsuario> Deserializar(string xml)
        {
            return (List<TipoUsuario>)CommonBC.Deserializar<List<TipoUsuario>>(xml);
        }

      
    }
}
