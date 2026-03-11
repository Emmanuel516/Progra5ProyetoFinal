using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private IProductoRepository objDatos = new ProductoRepository();

        public List<Producto> Listar()
        {
            return objDatos.Listar();
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del Producto no puede estar vacío.";
                return 0;
            }

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La Descripcion del Producto no puede estar vacía.";
                return 0;
            }

            if (obj.Precio <= 0)
            {
                mensaje = "El precio del producto debe ser mayor a 0";
                return 0;
            }

            if (obj.Stock < 0)
            {
                mensaje = "Stock negativo ";
                return 0;

                }    

            return objDatos.Registrar(obj, out mensaje);
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del Producto no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La Descripcion del Producto no puede estar vacía.";
                return false;
            }

            if (obj.Precio <= 0)
                {
                    mensaje = "El precio del producto debe ser mayor a 0";
                    return false;
                }

            if (obj.Stock < 0)
                {
                    mensaje = "Stock negativo ";
                    return false;
                }

                return objDatos.Editar(obj, out mensaje);
            }

        public bool Eliminar(int id, out string mensaje)
        {
            bool respuesta = objDatos.Eliminar(id, out mensaje);

            if (!respuesta && mensaje.Contains("foreign key constraint fails"))
            {
                mensaje = "No se puede eliminar este producto porque tiene una venta asignada.";
            }

            return respuesta;
        }
    }
}
