using CapaEntidad;
using System.Collections.Generic; 

namespace CapaDatos
{

    public interface IClienteRepository
    {
  
        List<Cliente> Listar();

        int Registrar(Cliente obj, out string mensaje);

        
        bool Editar(Cliente obj, out string mensaje);


        bool Eliminar(int id, out string mensaje);
    }
}