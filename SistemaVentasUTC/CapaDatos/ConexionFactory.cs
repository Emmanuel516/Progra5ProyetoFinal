using System;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class ConexionFactory
    {
        private static string cadenaConexion = "Server=localhost;Database=SistemaVentasUTC;Uid=root;Pwd=root;";

     
        public static MySqlConnection ObtenerConexion()
        {
        
            MySqlConnection conexionNueva = new MySqlConnection(cadenaConexion);

            return conexionNueva;
        }
    }
}