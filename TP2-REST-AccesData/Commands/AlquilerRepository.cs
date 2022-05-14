using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_AccesData.Commands
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly LibreriaDbContext _context;
        private readonly IAlquilerRepository _alquilerRepository;
        public AlquilerRepository(LibreriaDbContext context,
            IAlquilerRepository alquilerRepository)
        {
            _context = context;
            _alquilerRepository = alquilerRepository;
        }
          
        public Libro GetLibro(string isbn)
        {
            var libroGet = _context.Libros
                                       .Where(libro => libro.ISBN == isbn);

            return (Libro)libroGet;
        }

        public List<GetAlquilerByEstadoIdDto> GetByEstadoId(int estadoId)
        {
            var estado = _context.Alquileres
                                      .Where(alquiler => alquiler.Estado == estadoId);

            return (List<GetAlquilerByEstadoIdDto>)estado;
        }

        public List<GetLibrosByClienteDto> GetLibroByCliente(int idCliente)
        {
            var alquileres = _context.Alquileres
                                             .Where(libro => libro.Cliente == idCliente);

            return (List<GetLibrosByClienteDto>)alquileres;
        }

        public List<Alquiler> GetReserva(int clienteId, string isbn, int estadoId)
        {
            return _context.Alquileres
                                      .Where(alquiler => alquiler.Cliente == clienteId && alquiler.ISBN == isbn && alquiler.Estado == estadoId)
                                      .ToList();
        }

        public CreateAlquilerDto CreateAlquiler(AlquilerDto alquiler)
        {
            if (alquiler.FechaAlquiler == null || alquiler.FechaAlquiler == " ")
            {
                DateTime.TryParse(alquiler.FechaReserva, out DateTime fechavalida);
                var newAlquiler = new Alquiler
                {
                    Cliente = alquiler.ClienteId,
                    ISBN = alquiler.ISBN,
                    Estado = 1,
                    FechaReserva = fechavalida
                };
                _context.Add(newAlquiler);
                Libro libro = _alquilerRepository.GetLibro(alquiler.ISBN);
                libro.Stock -= 1;
                _context.Libros.Update(libro);
                _context.SaveChanges();

                return new CreateAlquilerDto {Alquiler = "Alquiler", Id = newAlquiler.ToString()};
            }
            else
            {
                DateTime.TryParse(alquiler.FechaAlquiler, out DateTime fechaValida);
                var newAlquiler = new Alquiler
                {
                    Cliente = alquiler.ClienteId,
                    ISBN = alquiler.ISBN,
                    Estado = 2,
                    FechaAlquiler = fechaValida,
                    FechaDevolucion = fechaValida.AddDays(7)
                };
                _context.Add(newAlquiler);
                Libro libro = _alquilerRepository.GetLibro(alquiler.ISBN);
                libro.Stock -= 1;
                _context.Libros.Update(libro);
                _context.SaveChanges();

                return new CreateAlquilerDto { Alquiler = "Alquiler", Id = newAlquiler.Id.ToString() };
            }
        }

        public void ModifyReserva(ModifyAlquilerDto modifyAlquilerDto)
        {
            List<Alquiler> reservas = _alquilerRepository.GetReserva(modifyAlquilerDto.ClienteId, modifyAlquilerDto.ISBN);
            foreach (Alquiler reserva in reservas)
            {
                reserva.Estado = 2;
                reserva.FechaAlquiler = DateTime.Now;
                reserva.FechaDevolucion = DateTime.Now.AddDays(7);
            }
            _context.Update(reservas);
            _context.SaveChanges();
        }

        public bool ExisteCliente(int clienteId)
        {
            return _context.Clientes.Any(x => x.ClienteId == clienteId);
        }

        public bool ExisteLibro(string isbn)
        {
            return _context.Libros.Any(x => x.ISBN == isbn);
        }

        public bool ExisteReservaDeCliente(int clienteId)
        {
            return _context.Clientes.Any(x => x.ClienteId == clienteId);
        }

        public bool ExisteReservaDeLibro(string isbn)
        {
            return _context.Libros.Any(X => X.ISBN == isbn);
        }

        public bool ExisteStock(string isbn)
        {
            return _context.Libros.Any(X => X.ISBN == isbn);
        }
        public void Update(Alquiler alquiler)
        {
            _context.Alquileres.Update(alquiler);
        }

        public List<Alquiler> GetReserva(int clienteId, string isbn)
        {
            var reserva = _context.Alquileres
                                      .Where(alquiler => alquiler.Cliente == clienteId);

            return (List<Alquiler>)reserva;
        }
    }
}
