using NETCOREHENRYTENORIOMVC.Models;
using System.Data.SqlClient;
using System.Data;


namespace NETCOREHENRYTENORIOMVC.Datos
{
    public class ReporteEstadoCuenta
    {

        public List<ReporteEstadoCuentaModel> ListarEstadoCuenta()
        {

            var oEstadoCuenta = new List<ReporteEstadoCuentaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {

              
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEstadoCuenta", conexion);
                //cmd.Parameters.AddWithValue("Cedula", cedula);
                //cmd.Parameters.AddWithValue("Fecha", fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEstadoCuenta.Add(new ReporteEstadoCuentaModel()
                        {
                            Cedula = Convert.ToInt32(dr["cedula"]),
                            Cliente = dr["cliente"].ToString(),
                            NumeroCuenta = dr["numeroCuenta"].ToString(),
                            tipoMovimiento = dr["tipo"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                        });

                    }
                }
            }

            return oEstadoCuenta;
        }
        public ReporteEstadoCuentaModel Obtener(int Cedula, DateTime fecha)
        {

            var oEstadoCuenta = new ReporteEstadoCuentaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerEstadoCuenta", conexion);
                cmd.Parameters.AddWithValue("Cedula", Cedula);
                cmd.Parameters.AddWithValue("Fecha", fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEstadoCuenta.Cedula = Convert.ToInt32(dr["Cedula"]);
                        oEstadoCuenta.Cliente =dr["Cliente"].ToString();
                        oEstadoCuenta.NumeroCuenta = dr["numeroCuenta"].ToString();
                        oEstadoCuenta.tipoMovimiento = dr["tipo"].ToString();
                        oEstadoCuenta.Fecha = Convert.ToDateTime(dr["fecha"]);
                        oEstadoCuenta.Valor = Convert.ToDecimal(dr["valor"]);
                    }
                }
            }

            return oEstadoCuenta;
        }

    }
}
