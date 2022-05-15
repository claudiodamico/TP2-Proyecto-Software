using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface IAlquilerRepository
    {
        CreateAlquilerDto CreateAlquiler(AlquilerDto alquiler);
        List<GetAlquilerByEstadoIdDto> GetByEstadoId(int estadoId);
        List<Alquiler> GetReserva(int clienteid, string isbn);
        Libro GetLibro(string isbn);
        List<GetLibrosByClienteDto> GetLibroByCliente(int idCliente);
        void ModifyReserva(ModifyAlquilerDto modifyAlquilerDto);
        bool ExisteCliente(int clienteId);
        public bool ExisteDNI(string dni);
        bool ExisteLibro(string isbn);
        bool ExisteStock(string isbn);
        bool ExisteReservaDeCliente(int clienteId);
        bool ExisteReservaDeLibro(string isbn);
        public void Update(Alquiler alquiler);
    }
}
