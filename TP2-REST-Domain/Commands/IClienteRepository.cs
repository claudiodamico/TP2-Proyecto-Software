using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_REST_Domain.Dtos;

namespace TP2_REST_Domain.Commands
{
    public interface IClienteRepository
    {
        List<ClienteDto> GetClientes(string nombre, string apellido, string dni);
    }
}
