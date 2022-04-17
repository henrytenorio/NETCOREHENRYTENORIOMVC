using NETCOREHENRYTENORIOMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace NETCOREHENRYTENORIOMVC.Datos
{
    public class CuentaDatos
    {

        public List<CuentaModel> Listar() { 
        
            var oLista = new List<CuentaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new CuentaModel() {
                            IdCuenta = Convert.ToInt32(dr["IdCuenta"]),
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Numero = Convert.ToInt32(dr["Numero"]),
                            Saldo = Convert.ToDecimal( dr["Saldo"])
                        });

                    }
                }
            }

            return oLista;
        }

        public CuentaModel Obtener(int IdCuenta)
        {

            var oCuenta = new CuentaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdCuenta", IdCuenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oCuenta.IdCuenta = Convert.ToInt32(dr["IdCuenta"]);
                        oCuenta.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        oCuenta.Numero = Convert.ToInt32(dr["Numero"]);
                        oCuenta.Saldo = Convert.ToDecimal(dr["Saldo"]);
                    }
                }
            }

            return oCuenta;
        }

        public bool Guardar(CuentaModel ocuenta) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", ocuenta.IdCliente);
                    cmd.Parameters.AddWithValue("Numero", ocuenta.Numero);
                    cmd.Parameters.AddWithValue("Saldo", ocuenta.Saldo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e) {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(CuentaModel ocuenta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdCuenta", ocuenta.IdCuenta);
                    cmd.Parameters.AddWithValue("IdCliente", ocuenta.IdCliente);
                    cmd.Parameters.AddWithValue("Numero", ocuenta.Numero);
                    cmd.Parameters.AddWithValue("Saldo", ocuenta.Saldo);
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

        public bool Eliminar(int IdCuenta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdCuenta", IdCuenta);
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
