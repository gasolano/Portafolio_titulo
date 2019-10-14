using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class GiroCollection
    {
        public List<Giro> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.GIRO.ToList());
        }

        private List<Giro> GenerarListado(List<DALC.GIRO> list)
        {
            List<Giro> info = new List<Giro>();
            foreach (DALC.GIRO item in list)
            {
                Giro g = new Giro();
                g.IdGiro = item.ID_GIRO;
                g.Nombre = item.NOMBRE;
                info.Add(g);
            }
            return info;
        }

        public static List<Giro> Deserializar(string xml)
        {
            return (List<Giro>)CommonBC.Deserializar<List<Giro>>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<List<Giro>>(this.ReadAll());
        }
    }
}
