using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PrevencionRiesgos.Negocio;

namespace PrevencionRiesgos.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PrevencionSvc : IPrevencion
    {
        public bool CreateUsuario(string xml)
        {

            try
            {

                Usuario u1 = Usuario.Deserializar(xml);
                if (u1.Create())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public string ReadUsuario(string xml)
        {

            try
            {

                Usuario u1 = Usuario.Deserializar(xml);
                if (u1.Read())
                {
                    return u1.Serializar();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        public string ReadTipoUsuario()
        {

            try
            {

                    return new TipoUsuarioCollection().Serializar();
               
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public string ReadClienteEmpresa()
        {

            try
            {

                return new EmpresasCollection().Serializar();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool ModificarUsuario(string xml)
        {

            try
            {

                Usuario u1 = Usuario.Deserializar(xml);

                return u1.Update();
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public string ReadUsuariosCollection()
        {

            try
            {

                return new UsuarioCollection().Serializar();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool ValidarUsuario(string xml)
        {
            try
            {
                Usuario u = Usuario.Deserializar(xml);
                return u.ValidarUsuario();
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public int ValidarUsuarioJava(string r, string p)
        {
            try
            {
                Usuario u = new UsuarioCollection().ReadAll().First(us => us.Rut == r && us.Pass == p);
                return u.IdTipo;
            }
            catch (Exception ex)
            {

                return 5;
            }

        }

        public string ReadUsuariosDesplegar()
        {
            try
            {

                return new UsuarioCollection().SerializarDesplegable();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
    
}
