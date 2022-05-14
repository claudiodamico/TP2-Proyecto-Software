using AutoMapper;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Aplication.Services
{
    public interface IClientesService
    {
        List<ClienteDto> GetCliente(string nombre = null, string apellido = null, string dni = null);
        Cliente CrearCliente(ClienteDto cliente);
        List<Cliente> GetAllClientes();       
    }
    public class ClienteService : IClientesService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public Cliente CrearCliente(ClienteDto cliente)
        {
            var clienteMapeado = _mapper.Map<Cliente>(cliente);
            _clienteRepository.AddCliente(clienteMapeado);

            return clienteMapeado;
        }

        public List<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes().ToList();
        }

        public List<ClienteDto> GetCliente(string? nombre = null, string? apellido = null, string dni = null)
        {
            var clientes = _clienteRepository.GetCliente(nombre, apellido, dni);

            return _mapper.Map<List<ClienteDto>>(clientes);
        }
    }
}
