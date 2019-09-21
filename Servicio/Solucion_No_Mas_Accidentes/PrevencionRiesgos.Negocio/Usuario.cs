using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrevencionRiesgos.DALC;

namespace PrevencionRiesgos.Negocio
{
    public class Usuario : ICrud
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



            private static Usuario _ULogueado;

            public Usuario ULogueado
            {
                get { return _ULogueado; }
                set { _ULogueado = value; }
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
            DALC.USUARIO emp = new DALC.USUARIO();
            try
            {
                emp = new DALC.USUARIO()
                {
                    RUT = Rut,
                    ID_TIPO = IdTipo,
                    PASS = Pass,
                    NOMBRES = Nombres,
                    APELLIDOM = ApellidoM,
                    APELLIDOP = ApellidoP,
                    CORREO = Correo,
                    TELEFONO = Telefono,
                    DIRECCION = Direccion
                };
                CommonBC.Modelo.USUARIO.Add(emp);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (CommonBC.Modelo.USUARIO.Contains(emp))
                {
                    CommonBC.Modelo.USUARIO.Remove(emp);
                }
                return false;
            }
            throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            public bool Delete()
            {
                throw new NotImplementedException();
            }



        }
    }
