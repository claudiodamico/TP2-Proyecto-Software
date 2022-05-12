using System.Linq;
using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_AccesData.Commands
{
    public class LibrosRepository : ILibrosRepository
    {
        private readonly LibreriaDbContext _context;
        public LibrosRepository(LibreriaDbContext context)
        {
            _context = context;
        }

        public Libro GetLibrosByStock(int? stock)
        {
            return _context.Libros.SingleOrDefault(libro => libro.Stock == stock);
        }

        public Libro GetLibrosByAutor(string autor)
        {
            return _context.Libros.SingleOrDefault(libro => libro.Autor == autor);
        }
     
        public Libro GetLibrosByTitulo(string titulo)
        {
            return _context.Libros.SingleOrDefault(libro => libro.Titulo == titulo);
        }

        public List<Libro> GetAllLibros()
        {
            return _context.Libros.ToList();
        }
    }
}
