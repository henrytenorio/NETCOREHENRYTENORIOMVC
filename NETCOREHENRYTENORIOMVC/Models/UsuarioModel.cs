﻿namespace NETCOREHENRYTENORIOMVC.Models
{
    public class UsuarioModel
    {

        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public string[] Roles { get; set; }
    }
}
