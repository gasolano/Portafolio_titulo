using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class TipoUsuarioCollection
    {

        public List<TipoUsuario> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.TIPO_USUARIO.ToList());
        }

        private List<TipoUsuario> GenerarListado(List<DALC.TIPO_USUARIO> list)
        {

            List<TipoUsuario> lu = new List<TipoUsuario>();
            TipoUsuario t;
            foreach (DALC.TIPO_USUARIO item in list)
            {
                t = new TipoUsuario();
                t.IdTipo = (int)item.ID_TIPO;
                t.Nombre = item.NOMBRE;
                lu.Add(t);
            }
            return lu;
        }

        public static List<TipoUsuario> Deserializar(string xml)
        {
            return (List<TipoUsuario>)CommonBC.Deserializar<List<TipoUsuario>>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<List<TipoUsuario>>(this.ReadAll());
        }

    }
}
