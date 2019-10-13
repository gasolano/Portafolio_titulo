using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public interface IDGUsuario
    {
        string Rut { get; set; }
        string Tipo_Usuario { get; set; }
        string Nombres { get; }
        string Apellidos { get; }
        string Correo { get; set; }
        string Telefono { get; }
        string Direccion { get; set; }
        string CMoroso { get; }
        string De_Baja { get; }
        string Empresa { get; set; }

    }
}
