using NETCOREHENRYTENORIOMVC.Models;
using System.Data.SqlClient;
using System.Data;


namespace NETCOREHENRYTENORIOMVC.Datos
{
    public class ClienteDatos
    {
        public List<ClienteModel> ListarClientes()
        {

            var oLista = new List<ClienteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarClientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Direccion= dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }

        public ClienteModel ObtenerCliente(int IdCliente)
        {

            var oCliente = new ClienteModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerCliente", conexion);
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oCliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Direccion = dr["Direccion"].ToString();
                        oCliente.Telefono= dr["Telefono"].ToString();
                    }
                }
            }

            return oCliente;
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
