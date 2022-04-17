namespace NETCOREHENRYTENORIOMVC.Models
{
    public class ReporteEstadoCuentaModel
    {
        public int Cedula { get; set; }
        public string Cliente { get; set; }  
        public string NumeroCuenta { get; set; }
        public string tipoMovimiento { get; set; }
        public DateTime? Fecha { get; set; } 
        public decimal Valor { get; set; }

    }
}
