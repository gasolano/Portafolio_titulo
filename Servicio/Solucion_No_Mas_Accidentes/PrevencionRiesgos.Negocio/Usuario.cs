using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrevencionRiesgos.DALC;

namespace PrevencionRiesgos.Negocio
{
    public class Usuario : ICrud, IDGUsuario 
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
            RutEmpresa = string.Empty   ;
         
        }


        public static Usuario Deserializar(string xml)
        {
            return (Usuario)CommonBC.Deserializar<Usuario>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<Usuario>(this);
        }



        public bool ValidarUsuario()
        {
            try
            {
                DALC.USUARIO u1 = CommonBC.Modelo.USUARIO.First(u => u.RUT == Rut && u.PASS == Pass);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        public bool ValidarUsuarioJ(string r, string p)
        {
            try
            {
                DALC.USUARIO u1 = CommonBC.Modelo.USUARIO.First(u => u.RUT == r && u.PASS == p);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Create()
        {

            try
            {
                DALC.USUARIO u = new DALC.USUARIO();
                u.RUT = Rut;
                u.ID_TIPO = IdTipo;
                u.PASS = Pass;
                u.NOMBRES = Nombres;
                u.APELLIDOP = ApellidoP;
                u.APELLIDOM = ApellidoM;
                u.CORREO = Correo;
                u.TELEFONO = Telefono;
                u.DIRECCION = Direccion;
                if (Moroso)
                {
                    u.MOROSO = 1;
                }
                else
                {
                    u.MOROSO = 0;
                }
                if (DarBaja)
                {
                    u.DAR_BAJA = 1;
                }
                else
                {
                    u.DAR_BAJA = 0;
                }
                u.RUT_EMPRESA = RutEmpresa;

                CommonBC.Modelo.USUARIO.Add(u);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                DALC.USUARIO u1 = CommonBC.Modelo.USUARIO.First(u => u.RUT == Rut);



                Rut = u1.RUT;
                IdTipo = (int)u1.ID_TIPO;
                Pass = u1.PASS;
                Nombres = u1.NOMBRES;
                ApellidoP = u1.APELLIDOP;
                ApellidoM = u1.APELLIDOM;
                Correo = u1.CORREO;
                Telefono = u1.TELEFONO;
                Direccion = u1.DIRECCION;
                if (u1.MOROSO == 1)
                {
                    Moroso = true;
                }
                if (u1.DAR_BAJA == 1)
                {
                    DarBaja = true;
                }
                RutEmpresa = u1.RUT_EMPRESA;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {

            //        public string Rut { get; set; }
            //public int IdTipo { get; set; }
            //public string Pass { get; set; }
            //public string Nombres { get; set; }
            //public string ApellidoP { get; set; }
            //public string ApellidoM { get; set; }
            //public string Correo { get; set; }
            //public string Telefono { get; set; }
            //public string Direccion { get; set; }
            //public bool Moroso { get; set; }
            //public bool DarBaja { get; set; }
            //public string RutEmpresa { get; set; }

            try
            {
                DALC.USUARIO u = CommonBC.Modelo.USUARIO.First(u1 => u1.RUT == Rut);

                u.ID_TIPO = IdTipo;
                u.PASS = Pass;
                u.NOMBRES = Nombres;
                u.APELLIDOP = ApellidoP;
                u.APELLIDOM = ApellidoM;
                u.CORREO = Correo;
                u.TELEFONO = Telefono;
                u.DIRECCION = Direccion;
                if (Moroso)
                {
                    u.MOROSO = 1;
                }
                else
                {
                    u.MOROSO = 0;
                }
                if (DarBaja)
                {
                    u.DAR_BAJA = 1;
                }
                else
                {
                    u.DAR_BAJA = 0;
                }
                u.RUT_EMPRESA = RutEmpresa;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }



    }
}
