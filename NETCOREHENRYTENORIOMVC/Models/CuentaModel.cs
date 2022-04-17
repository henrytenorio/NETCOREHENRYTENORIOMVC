using System.ComponentModel.DataAnnotations;

namespace NETCOREHENRYTENORIOMVC.Models
{
    public class CuentaModel
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }

        [Required(ErrorMessage ="El campo Número de cuenta es obligatorio")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "El campo Saldo es obligatorio")]
        public decimal Saldo { get; set; }
       

    }
}
