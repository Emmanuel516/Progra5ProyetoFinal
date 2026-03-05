using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    
    public class ClienteRepository : IClienteRepository
    {
    
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT IdCliente, Nombre, Telefono, Correo FROM Clientes";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open(); 

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Nombre = dr["Nombre"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>(); 
                }
            }
            return lista;
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            int idClienteGenerado = 0; 
            mensaje = string.Empty;

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                    
                    string query = "INSERT INTO Clientes(Nombre, Telefono, Correo) VALUES(@nombre, @telefono, @correo);" +
                                   "SELECT LAST_INSERT_ID();"; 

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@correo", obj.Correo);

                    oconexion.Open();

                    idClienteGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idClienteGenerado = 0;
                    mensaje = ex.Message; 
                }
            }
            return idClienteGenerado;
        }

        public bool Editar(Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                    string query = "UPDATE Clientes SET Nombre = @nombre, Telefono = @telefono, Correo = @correo WHERE IdCliente = @id";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);

                    oconexion.Open();

                    
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }
        public bool Eliminar(int id, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                    string query = "DELETE FROM Clientes WHERE IdCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@id", id);

                    oconexion.Open();

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }
    }
}