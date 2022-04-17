using System.ComponentModel.DataAnnotations;

namespace NETCOREHENRYTENORIOMVC.Models
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "El campo cedula es obligatorio")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El campo nombre de cuenta es obligatorio")]
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
