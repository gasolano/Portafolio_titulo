using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class RegionCollection
    {
        public List<Region> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.REGION.ToList());
        }
        private List<Region> GenerarListado(List<DALC.REGION> list)
        {
            List<Region> info = new List<Region>();
            foreach (DALC.REGION item in list)
            {
                Region r = new Region();
                r.IdRegion = item.ID_REGION;
                r.Nombre = item.NOMBRE;
                foreach (var ciudad in item.CIUDAD)
                {
                    var c = new Ciudad();
                    c.IdCiudad = ciudad.ID_CIUDAD;
                    c.IdRegion = ciudad.ID_REGION;
                    c.Nombre = ciudad.NOMBRE;
                    foreach (var comuna in ciudad.COMUNA)
                    {
                        var co = new Comuna();
                        co.IdComuna = comuna.ID_COMUNA;
                        co.IdCiudad = comuna.ID_CIUDAD;
                        co.Nombre = comuna.NOMBRE;
                        c.Comunas.Add(co);
                    }
                    r.Ciudades.Add(c);
                }
                info.Add(r);
            }
            return info;
        }

        public static List<Region> Deserializar(string xml)
        {
            return (List<Region>)CommonBC.Deserializar<List<Region>>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<List<Region>>(this.ReadAll());
        }
    }
}
