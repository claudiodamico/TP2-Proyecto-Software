using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Aplication.Services
{
    public interface IAlquilerService
    {
        CreateAlquilerDto CreateAlquiler(AlquilerDto alquiler);
        List<Alquiler> GetByEstadoId(int estadoid);
        List<Alquiler> GetReserva(int clienteid, string isbn, int estadoId);
        Libro GetLibro(string isbn);
        List<Alquiler> GetLibroByCliente(int idCliente);
        void ModifyReserva(ModifyAlquilerDto modifyAlquilerDto);
        bool ExisteCliente(int clienteId);
        bool ExisteLibro(string isbn);
        bool ExisteStock(string isbn);
        bool ExisteReservaDelCliente(int clienteId);
        bool ExisteReservaDelLibro(string isbn);
    }
    public class AlquilerService : IAlquilerService
    {
        private readonly IAlquilerRepository _alquilerRepository;

        public AlquilerService(IAlquilerRepository alquilerRepository)
        {
            _alquilerRepository = alquilerRepository;;   
        }

        public CreateAlquilerDto CreateAlquiler(AlquilerDto alquiler)
        {
            return _alquilerRepository.CreateAlquiler(alquiler);
        }

        public bool ExisteCliente(int clienteId)
        {
            return _alquilerRepository.ExisteCliente(clienteId);
        }

        public bool ExisteLibro(string isbn)
        {
            return _alquilerRepository.ExisteLibro(isbn);
        }

        public bool ExisteReservaDelCliente(int clienteId)
        {
            return _alquilerRepository.ExisteReservaDeCliente(clienteId);
        }

        public bool ExisteReservaDelLibro(string isbn)
        {
            return _alquilerRepository.ExisteReservaDeLibro(isbn);
        }

        public bool ExisteStock(string isbn)
        {
            return _alquilerRepository.ExisteStock(isbn);
        }

        public List<Alquiler> GetByEstadoId(int estadoid)
        {
            return _alquilerRepository.GetByEstadoId(estadoid);
        }

        public Libro GetLibro(string isbn)
        {
            return _alquilerRepository.GetLibro(isbn);
        }

        public List<Alquiler> GetLibroByCliente(int idCliente)
        {
            var alquileresByClient = _alquilerRepository.GetLibroByCliente(idCliente);
            
            return alquileresByClient;
        }

        public List<Alquiler> GetReserva(int clienteid, string isbn, int estadoId)
        {
            return _alquilerRepository.GetReserva(clienteid, isbn);
        }

        public void ModifyReserva(ModifyAlquilerDto modifyAlquilerDto)
        {
             _alquilerRepository.ModifyReserva(modifyAlquilerDto);
        }
    }
}
