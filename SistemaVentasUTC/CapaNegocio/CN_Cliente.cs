using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private IClienteRepository objDatos = new ClienteRepository();

        public List<Cliente> Listar()
        {
            return objDatos.Listar();
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del cliente no puede estar vacío.";
                return 0;
            }

            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo del cliente no puede estar vacío.";
                return 0;
            }

            return objDatos.Registrar(obj, out mensaje);
        }

        public bool Editar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del cliente no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo del cliente no puede estar vacío.";
                return false;
            }

            return objDatos.Editar(obj, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            bool respuesta = objDatos.Eliminar(id, out mensaje);

            if (!respuesta && mensaje.Contains("foreign key constraint fails"))
            {
                mensaje = "No se puede eliminar este cliente porque ya tiene un historial de compras registrado.";
            }

            return respuesta;
        }
    }
}