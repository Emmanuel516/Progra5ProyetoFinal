using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos
{
    public interface IProductoRepository
    {

        List<Producto> Listar();

        int Registrar(Producto obj, out string mensaje);


        bool Editar(Producto obj, out string mensaje);


        bool Eliminar(int id, out string mensaje);
    }
}
