using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    interface ICrud
    {
        bool Create();
        bool Read();
        bool Update();
        bool Delete();
    }
}
