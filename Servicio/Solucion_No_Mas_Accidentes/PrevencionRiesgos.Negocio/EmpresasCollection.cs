using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class EmpresasCollection
    {
        public List<ClienteEmpresa> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.CLIENTE_EMPRESA.ToList());
        }

        private List<ClienteEmpresa> GenerarListado(List<DALC.CLIENTE_EMPRESA> list)
        {

            List<ClienteEmpresa> lce = new List<ClienteEmpresa>();
            ClienteEmpresa c;
            foreach (DALC.CLIENTE_EMPRESA item in list)
            {
                c = new ClienteEmpresa();
                c.Rut = item.RUT;
                c.IdGiro = item.ID_GIRO;
                c.IdComuna = item.ID_COMUNA;
                c.Nombre = item.NOMBRE;
                c.Telefono = item.TELEFONO;
                c.Direccion = item.DIRECCION;
                c.Correo = item.CORREO;
                c.ClienteMoroso = item.CLIENTE_MOROSO;
                lce.Add(c);
            }
            return lce;
        }

        public static List<ClienteEmpresa> Deserializar(string xml)
        {
            return (List<ClienteEmpresa>)CommonBC.Deserializar<List<ClienteEmpresa>>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<List<ClienteEmpresa>>(this.ReadAll());
        }
    }
}
