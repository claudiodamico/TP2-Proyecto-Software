using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
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

        public List<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }   

        public List<Cliente> GetCliente(string? nombre = null, string? apellido = null, string? dni = null)
        {
            return _context.Clientes.
                                    Where(cliente => (string.IsNullOrEmpty(nombre) || cliente.Nombre == nombre) &&
                                    (string.IsNullOrEmpty(apellido) || cliente.Apellido == apellido) &&
                                    (string.IsNullOrEmpty(dni) || cliente.Dni == dni)).ToList();
        }

        public void AddCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Delete(GetClienteById(id));
        }
    }
}
