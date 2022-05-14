using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        List<Cliente> GetAllClientes();
        Cliente GetClienteByNombre(string nombre);
        Cliente GetClienteByApellido(string apellido);
        Cliente GetClienteByDni(string dni);
    }
}
