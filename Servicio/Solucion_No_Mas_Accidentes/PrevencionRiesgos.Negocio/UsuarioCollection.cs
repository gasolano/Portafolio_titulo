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
                u.RutEmpresa = item.RUT;
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
    }
}
