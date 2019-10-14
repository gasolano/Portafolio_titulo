using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class Ciudad : ICrud
    {
        public decimal IdCiudad { get; set; }
        public string Nombre { get; set; }
        public decimal IdRegion { get; set; }
        public List<Comuna> Comunas{ get; set; }
        public Ciudad()
        {
            Comunas = new List<Comuna>();
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
                var resultado = CommonBC.Modelo.CIUDAD.First(X => X.ID_CIUDAD == IdCiudad);
                Nombre = resultado.NOMBRE;
                IdRegion = resultado.ID_REGION;
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
