using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface IAquilerRepository
    {
        List<GetAlquilerByEstadoIdDto> GetByEstadoId(int estadoId);
        List<Alquiler> GetReserva(int clienteid, string isbn, int estadoId);
        Libro GetLibro(string isbn);
        List<GetLibrosByClienteDto> GetLibroByCliente(int idCliente);
        bool ExisteCliente(int clienteId);
        bool ExisteLibro(string isbn);
        bool ExisteStock(string isbn);
        bool ExisteReservaDeCliente(int clienteId);
        bool ExisteReservaDeLibro(string isbn);
    }
}
