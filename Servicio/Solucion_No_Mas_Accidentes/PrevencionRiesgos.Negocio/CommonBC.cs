using PrevencionRiesgos.DALC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrevencionRiesgos.Negocio
{
    public class CommonBC
    {
        private static PrevencionRiesgosEntities _modelo;

        public static PrevencionRiesgosEntities Modelo
        {
            get
            {
                if (_modelo == null)
                {
                    _modelo = new PrevencionRiesgosEntities();
                }
                return _modelo;
            }

        }

        public static string Serializar<T>(object objeto)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter();

            serializador.Serialize(writer, objeto);

            return writer.ToString();
        }

        public static object Deserializar<T>(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);

            return serializador.Deserialize(reader);
        }

    }
}
