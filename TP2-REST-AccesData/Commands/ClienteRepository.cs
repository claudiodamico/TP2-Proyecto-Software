using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_AccesData.Commands
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LibreriaDbContext _context;

        public ClienteRepository(LibreriaDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
        {
            if(cliente != null)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("El dni ingresado ya esta registrado!");
            }           
        }

        public List<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetClienteByApellido(string apellido)
        {
            return _context.Clientes.SingleOrDefault(cliente => cliente.Apellido == apellido);
        }

        public Cliente GetClienteByDni(string dni)
        {
            return _context.Clientes.SingleOrDefault(cliente => cliente.Dni == dni);
        }

        public Cliente GetClienteByNombre(string nombre)
        {
            return _context.Clientes.SingleOrDefault(cliente => cliente.Nombre == nombre);
        }
    }
}
