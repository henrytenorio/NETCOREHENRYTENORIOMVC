using NETCOREHENRYTENORIOMVC.Models;

namespace NETCOREHENRYTENORIOMVC.Datos
{
    public class UsuarioDatos
    {
        public List<UsuarioModel> ListaUsuario()
        {

            return new List<UsuarioModel>
            {
                new UsuarioModel{ Nombre ="Henry", Correo = "administrador@gmail.com", Clave= "123" , Roles = new string[]{"ROLE_ADMIN"} },
                new UsuarioModel{ Nombre ="Geovanny", Correo = "usuario@gmail.com", Clave= "123" , Roles = new string[]{ "ROLE_USER" } },
                
            };

        }

        public UsuarioModel ValidarUsuario(string _correo, string _clave)
        {

            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();

        }


    }
}
