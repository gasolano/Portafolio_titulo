using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrevencionRiesgos.DALC;

namespace PrevencionRiesgos.Negocio
{
    public class UsuarioCollection
    {
        public List<Usuario> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.USUARIO.ToList());
        }

        private List<Usuario> GenerarListado(List<DALC.USUARIO> list)
        {

            List<Usuario> ltu = new List<Usuario>();
            Usuario u;
            foreach (DALC.USUARIO item in list)
            {
                u = new Usuario();
                u.Nombres = item.NOMBRES;
                u.Pass = item.PASS;
                u.Rut = item.RUT;
                u.IdTipo = (int)item.ID_TIPO;
                u.ApellidoP = item.APELLIDOP;
                u.ApellidoM = item.APELLIDOM;
                u.Correo = item.CORREO;
                u.Telefono = item.TELEFONO;
                u.Direccion = item.DIRECCION;
                u.RutEmpresa = item.RUT_EMPRESA;
                //u.Tipo_Usuario = CommonBC.Modelo.TIPO_USUARIO.First(tp => tp.ID_TIPO == item.ID_TIPO).NOMBRE;
                //u.Empresa = CommonBC.Modelo.CLIENTE_EMPRESA.First(ce => ce.RUT == item.RUT_EMPRESA).NOMBRE;
                if (item.MOROSO == 1)
                {
                    u.Moroso = true;
                }
                if (item.DAR_BAJA == 1)
                {
                    u.DarBaja = true;
                }
                ltu.Add(u);
            }
            return ltu;
        }

        public static List<TipoUsuario> Deserializar(string xml)
        {
            return (List<TipoUsuario>)CommonBC.Deserializar<List<TipoUsuario>>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<List<Usuario>>(this.ReadAll());
        }


        public List<IDGUsuario> ListaDesplegable(List<Usuario> lu)
        {
            return lu.Select(u => (IDGUsuario)u).ToList<IDGUsuario>();







        }

        public string SerializarDesplegable()
        {
            return CommonBC.Serializar<List<IDGUsuario>>(ListaDesplegable(this.ReadAll()).ToList<IDGUsuario>());
        }

    }
}
