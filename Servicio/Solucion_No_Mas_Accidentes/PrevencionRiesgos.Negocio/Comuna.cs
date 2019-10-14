using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class Comuna : ICrud
    {
        public decimal IdComuna { get; set; }
        public decimal IdCiudad { get; set; }
        public string Nombre { get; set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {
                var resultado = CommonBC.Modelo.COMUNA.First(X => X.ID_COMUNA == IdComuna);
                Nombre = resultado.NOMBRE;
                IdCiudad = resultado.ID_CIUDAD;

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
    }
}
