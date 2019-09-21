using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
   public class TipoUsuario
    {

        public int IdTipo { get; set; }
        public string Nombre { get; set; }

        public TipoUsuario()
        {
            this.Init();
        }


        private void Init()
        {
            IdTipo = 0;
            Nombre = string.Empty;
        }

    }
}
