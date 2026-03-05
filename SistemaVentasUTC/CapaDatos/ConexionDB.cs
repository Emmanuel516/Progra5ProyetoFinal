using System;
using MySql.Data.MySqlClient; 

namespace CapaDatos
{
    public class ConexionDB
    {
        private static string cadena = "Server=localhost;Database=SistemaVentasUTC;Uid=root;Pwd=root;";

        
        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadena);
                return conexion;
            }
            catch (Exception ex)
            {
                return null; 
            }
        }
    }
}