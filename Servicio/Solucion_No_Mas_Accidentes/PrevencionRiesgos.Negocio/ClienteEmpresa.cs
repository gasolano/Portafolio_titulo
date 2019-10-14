using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class ClienteEmpresa : ICrud
    {
        public string Rut { get; set; }
        public decimal IdGiro { get; set; }
        public decimal IdComuna { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public decimal ClienteMoroso { get; set; }

        public ClienteEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            Rut = string.Empty;
            IdGiro = 0;
            IdComuna = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Correo = string.Empty;
            ClienteMoroso = 0;
        }

        public bool Create()
        {
            try
            {
                DALC.CLIENTE_EMPRESA info = new DALC.CLIENTE_EMPRESA()
                {
                    RUT = Rut,
                    ID_GIRO = IdGiro,
                    CLIENTE_MOROSO = ClienteMoroso,
                    CORREO = Correo,
                    DIRECCION = Direccion,
                    ID_COMUNA = IdComuna,
                    NOMBRE = Nombre,
                    TELEFONO = Telefono
                };
                CommonBC.Modelo.CLIENTE_EMPRESA.Add(info);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                DALC.CLIENTE_EMPRESA c1 = CommonBC.Modelo.CLIENTE_EMPRESA.First(c => c.RUT == Rut);

                Rut = string.Empty;
                IdGiro = 0;
                IdComuna = 0;
                Nombre = string.Empty;
                Telefono = string.Empty;
                Direccion = string.Empty;
                Correo = string.Empty;
                ClienteMoroso = 0;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public static ClienteEmpresa Deserializar(string xml)
        {
            return (ClienteEmpresa)CommonBC.Deserializar<ClienteEmpresa>(xml);
        }
    }
}
