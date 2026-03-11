using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{

    public class ProductoRepository : IProductoRepository
    {

        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT IdProducto, Codigo, Nombre, Descripcion, Precio, Stock FROM Productos";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Stock = Convert.ToInt32(dr["Stock"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }
            }
            return lista;
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            int idProductoGenerado = 0;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {

                    string query = "INSERT INTO Productos(Codigo, Nombre, Descripcion, Precio, Stock) VALUES(@codigo, @nombre, @descripcion, @precio, @stock);" +
                                   "SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("@stock", obj.Stock);

                    oconexion.Open();

                    idProductoGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idProductoGenerado = 0;
                    mensaje = ex.Message;
                }
            }
            return idProductoGenerado;
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                    string query = "UPDATE Productos SET  Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock  WHERE IdProducto = @id";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("@stock", obj.Stock);
                    cmd.Parameters.AddWithValue("@id", obj.IdProducto);

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
                    string query = "DELETE FROM Productos WHERE IdProducto = @id";
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
