using NETCOREHENRYTENORIOMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace NETCOREHENRYTENORIOMVC.Datos
{
    public class MovimientoDatos
    {
        public List<MovimientoModel> ListarMovimientos()
        {

            var oLista = new List<MovimientoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarMovimientos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new MovimientoModel()
                        {
                            IdMovimiento = Convert.ToInt32(dr["IdMovimiento"]),
                            NumeroCuenta = dr["Numero"].ToString(),
                            Tipo = dr["Tipo"].ToString(),
                            Fecha = Convert.ToDateTime( dr["Fecha"]),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                        });

                    }
                }
            }

            return oLista;
        }

        public MovimientoModel ObtenerMovimiento(int IdMovimiento)
        {

            var oMovimiento = new MovimientoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerMovimiento", conexion);
                cmd.Parameters.AddWithValue("IdMovimiento", IdMovimiento);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oMovimiento.IdMovimiento = Convert.ToInt32(dr["IdMovimiento"]);
                        oMovimiento.NumeroCuenta= dr["Numero"].ToString();
                        oMovimiento.Tipo = dr["Tipo"].ToString();
                        oMovimiento.Fecha = Convert.ToDateTime(dr["Telefono"]);
                        oMovimiento.Valor = Convert.ToDecimal(dr["Valor"]);
                    }
                }
            }

            return oMovimiento;
        }

        public bool GuardarCliente(ClienteModel ocliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarCliente", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", ocliente.IdCliente);
                    cmd.Parameters.AddWithValue("Nombre", ocliente.Nombre);
                    cmd.Parameters.AddWithValue("Direccion", ocliente.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", ocliente.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool EditarCliente(ClienteModel ocuenta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarCliente", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", ocuenta.IdCliente);
                    cmd.Parameters.AddWithValue("Nombre", ocuenta.Nombre);
                    cmd.Parameters.AddWithValue("Direccion", ocuenta.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", ocuenta.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool EliminarCliente(int IdCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarCliente", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
