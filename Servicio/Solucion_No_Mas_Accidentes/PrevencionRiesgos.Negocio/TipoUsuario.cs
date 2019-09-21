using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
   public class TipoUsuario : ICrud
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

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {
                DALC.TIPO_USUARIO t1 = CommonBC.Modelo.TIPO_USUARIO.First(t => t.ID_TIPO == IdTipo);

                Nombre = t1.NOMBRE;

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
    }
}
