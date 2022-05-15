using Microsoft.EntityFrameworkCore;
using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_AccesData.Commands
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly LibreriaDbContext _context;
        public AlquilerRepository(LibreriaDbContext context)
        {
            _context = context;
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
                                      .SingleOrDefault(alquiler => alquiler.Estado == estadoId);

            return new List<GetAlquilerByEstadoIdDto>();
        }

        public List<GetLibrosByClienteDto> GetLibroByCliente(int idCliente)
        {
            var alquileres = _context.Alquileres
                                                .Where(libro => libro.Cliente == idCliente);

            return (List<GetLibrosByClienteDto>)alquileres;
        }

        public List<Alquiler> GetReserva(int clienteId, string isbn)
        {
            return _context.Alquileres
                                      .Where(alquiler => alquiler.Cliente == clienteId && alquiler.ISBN == isbn && alquiler.Estado == 1)
                                      .ToList();
        }

        public CreateAlquilerDto CreateAlquiler(AlquilerDto alquiler)
        {
            if (alquiler.FechaAlquiler == null && alquiler.FechaAlquiler == "")
            {
                var newAlquiler = new Alquiler
                {
                    Cliente = alquiler.ClienteId,
                    ISBN = alquiler.ISBN,
                    Estado = 1,
                    FechaReserva = DateTime.Now
                };
                _context.Add(newAlquiler);
                var libro = _context.Libros.SingleOrDefault(libro => libro.ISBN == alquiler.ISBN);
                libro.Stock -= 1;
                _context.Libros.Update(libro);
                _context.SaveChanges();

                return new CreateAlquilerDto {Alquiler = "Reserva", Id = newAlquiler.ToString()};
            }
            else
            {
                var newAlquiler = new Alquiler
                {
                    Cliente = alquiler.ClienteId,
                    ISBN = alquiler.ISBN,
                    Estado = 2,
                    FechaAlquiler = DateTime.Now,
                    FechaDevolucion = DateTime.Now.AddDays(7)
                };
                _context.Add(newAlquiler);
                Libro libro = _context.Libros.SingleOrDefault(libro => libro.ISBN == newAlquiler.ISBN);
                libro.Stock -= 1;
                _context.Libros.Update(libro);
                _context.SaveChanges();

                return new CreateAlquilerDto {Alquiler = "Alquiler", Id = newAlquiler.Id.ToString()};
            }
        }

        public void ModifyReserva(ModifyAlquilerDto modifyAlquilerDto)
        {
            List<Alquiler> reservas = _context.Alquileres
                                      .Where(alquiler => alquiler.Cliente == modifyAlquilerDto.ClienteId 
                                      && alquiler.ISBN == modifyAlquilerDto.ISBN)
                                      .ToList();
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
            return _context.Clientes.Any(cliente => cliente.ClienteId == clienteId);
        }

        public bool ExisteDNI(string dni)
        {
            return _context.Clientes.Any(x => x.Dni == dni); 
        }

        public bool ExisteLibro(string isbn)
        {
            return _context.Libros.Any(libro => libro.ISBN == isbn);
        }

        public bool ExisteReservaDeCliente(int clienteId)
        {
            return _context.Clientes.Any(x => x.ClienteId == clienteId);
        }

        public bool ExisteReservaDeLibro(string isbn)
        {
            return _context.Libros.Any(libro => libro.ISBN == isbn);
        }

        public bool ExisteStock(string isbn)
        {
            return _context.Libros.Any(libro => libro.ISBN == isbn);
        }
        public void Update(Alquiler alquiler)
        {
            _context.Alquileres.Update(alquiler);
        }
    }
}
