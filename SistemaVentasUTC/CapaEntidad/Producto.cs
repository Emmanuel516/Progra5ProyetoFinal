namespace CapaEntidad
{
    public class Producto
    {
        public Producto()
        {
        }

        public Producto(int idProducto, string nombre, string codigo, string descripcion, decimal precio, int stock)
        {
            IdProducto = idProducto;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Codigo { get; set; }

       


       
    }
}
