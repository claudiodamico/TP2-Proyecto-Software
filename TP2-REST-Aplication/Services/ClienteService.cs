using AutoMapper;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Aplication.Services
{
    public interface IClientesService
    {
        Cliente CrearCliente(ClienteDto cliente);
        List<Cliente> GetAllClientes();
        Cliente GetClienteByNombre(string nombre);
        Cliente GetClienteByApellido(string apellido);
        Cliente GetClienteByDni(string dni);
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
            _clienteRepository.Add(clienteMapeado);

            return clienteMapeado;
        }

        public List<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes().ToList();
        }

        public Cliente GetClienteByApellido(string apellido)
        {
            return _clienteRepository.GetClienteByApellido(apellido);
        }

        public Cliente GetClienteByDni(string dni)
        {
            return _clienteRepository.GetClienteByApellido(dni);
        }

        public Cliente GetClienteByNombre(string nombre)
        {
            return _clienteRepository.GetClienteByNombre(nombre);
        }
    }
}
