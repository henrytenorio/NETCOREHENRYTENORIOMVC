using System.ComponentModel.DataAnnotations;

namespace NETCOREHENRYTENORIOMVC.Models
{
    public class MovimientoModel
    {
        public int IdMovimiento { get; set; }

        [Required(ErrorMessage = "El campo nùmero de cuenta es obligatorio")]
        public string? NumeroCuenta { get; set; }
        [Required(ErrorMessage = "El campo tipo es obligatorio")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo valor es obligatorio")]
        public decimal Valor { get; set; }
    }
}
