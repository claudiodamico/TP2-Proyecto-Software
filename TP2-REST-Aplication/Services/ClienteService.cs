using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Aplication.Services
{
    public class ClienteService : IClienteRepository
    {
        private readonly IClienteRepository _clienteService;

        public ClienteService(IClienteRepository clienteService)
        {
            _clienteService = clienteService;
        }

        public List<ClienteDto> GetClientes(string nombre, string apellido, string dni)
        {
            return _clienteService.GetClientes(nombre, apellido, dni);
        }
    }
}
