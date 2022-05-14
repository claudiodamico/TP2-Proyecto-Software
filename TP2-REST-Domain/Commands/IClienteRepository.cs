using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface IClienteRepository
    {      
        List<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        List<Cliente> GetCliente(string? nombre = null, string? apellido = null, string? dni = null);
        void AddCliente(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        void DeleteById(int id);
    }
}
