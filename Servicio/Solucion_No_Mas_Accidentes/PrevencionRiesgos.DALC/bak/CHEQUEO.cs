//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrevencionRiesgos.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHEQUEO
    {
        public decimal ID_SERVICIO { get; set; }
        public decimal ID_CHEQUEO { get; set; }
        public string RUT_EMPRESA { get; set; }
        public decimal ID_VISITA { get; set; }
        public decimal ID_ITEM { get; set; }
        public decimal DESCRIPCION { get; set; }
        public decimal CUMPLE { get; set; }
        public decimal DAR_BAJA { get; set; }
    
        public virtual CLIENTE_EMPRESA CLIENTE_EMPRESA { get; set; }
        public virtual VISITA VISITA { get; set; }
    }
}
