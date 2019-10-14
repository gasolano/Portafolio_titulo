using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class Region : ICrud
    {
        public decimal IdRegion { get; set; }
        public string Nombre { get; set; }
        public List<Ciudad> Ciudades { get; set; }
        public Region()
        {
            Ciudades = new List<Ciudad>();
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
                var resultado = CommonBC.Modelo.REGION.First(X => X.ID_REGION == IdRegion);
                Nombre = resultado.NOMBRE;
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
