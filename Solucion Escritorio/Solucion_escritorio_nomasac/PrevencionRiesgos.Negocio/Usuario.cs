using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrevencionRiesgos.Negocio
{
    public class Usuario: IDGUsuario
    {
        public string Rut { get; set; }
        public int IdTipo { get; set; }
        public string Pass { get; set; }
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Moroso { get; set; }
        public bool DarBaja { get; set; }
        public string RutEmpresa { get; set; }
        public string Tipo_Usuario { get; set; }
        public string Empresa { get; set; }


        private static Usuario _ULogueado;

        public Usuario ULogueado
        {
            get { return _ULogueado; }
            set { _ULogueado = value; }
        }

        private static Usuario _UVisualizar;

        public Usuario UVisualizar
        {
            get { return _UVisualizar; }
            set { _UVisualizar = value; }
        }

        private static DateTime _HLogin;

        public DateTime HLogin
        {
            get { return _HLogin; }
            set { _HLogin = value; }
        }

      
        public string Apellidos
        {
            get
            {
                return string.Format("{0} {1}", ApellidoP, ApellidoM);
            }
        }

        public string CMoroso
        {
            get
            {
                if (Moroso)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }

        public string De_Baja
        {
            get
            {
                if (DarBaja)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }

 

      

   

        public Usuario()
        {
            this.Init();
        }

        private void Init()
        {
            Rut = string.Empty;
            IdTipo = 0;
            Pass = string.Empty;
            Nombres = string.Empty; ;
            ApellidoP = string.Empty;
            ApellidoM = string.Empty;
            Correo = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Moroso = false;
            DarBaja = false;
            RutEmpresa = string.Empty;
         
        }

        public static Usuario Deserializar(string xml)
        {
            return (Usuario)CommonBC.Deserializar<Usuario>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<Usuario>(this);
        }



    }
}
