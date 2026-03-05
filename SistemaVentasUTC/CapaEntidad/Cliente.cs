namespace CapaEntidad
{
    public class Cliente
    {

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Cliente() { }

   
        public Cliente(int id, string nombre, string telefono, string correo)
        {
            IdCliente = id;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }
    }
}