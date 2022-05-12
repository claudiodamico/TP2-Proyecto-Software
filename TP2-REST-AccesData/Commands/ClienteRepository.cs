using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_AccesData.Commands
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LibreriaDbContext _context;

        public ClienteRepository(LibreriaDbContext context)
        {
            _context = context;
        }
        public List<ClienteDto> GetClientes(string nombre, string apellido, string dni)
        {
            return Ok();
        }

        private List<ClienteDto> Ok()
        {
            throw new NotImplementedException();
        }
    }
}
