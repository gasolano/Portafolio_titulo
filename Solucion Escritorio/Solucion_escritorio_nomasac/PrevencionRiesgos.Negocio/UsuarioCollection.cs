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
        public static List<IDGUsuario> DeserializarDesplegable(string xml)
        {
            return (List<IDGUsuario>)CommonBC.Deserializar<List<IDGUsuario>>(xml);
        }

        public List<IDGUsuario> ListaDesplegable(List<Usuario> lu)
        {
            return lu.Select(u => (IDGUsuario)u).ToList<IDGUsuario>();
        }
    }
}
