using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PrevencionRiesgos.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPrevencion
    {

        [OperationContract]
        bool ValidarUsuario(string xml);

        [OperationContract]
        string ReadUsuario(string xml);

        [OperationContract]
        int ValidarUsuarioJava(string r, string p);

        [OperationContract]
        string ReadTipoUsuario();

        [OperationContract]
        string ReadUsuariosCollection();
        
        [OperationContract]
        bool CrearUsuario(string xml);
    }
}
