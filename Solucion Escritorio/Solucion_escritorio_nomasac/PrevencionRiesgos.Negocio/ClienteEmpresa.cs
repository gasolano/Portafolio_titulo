using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
   public class ClienteEmpresa
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

    }
}
