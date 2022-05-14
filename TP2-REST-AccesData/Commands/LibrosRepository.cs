using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
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

        public List<Libro> GetAllLibros()
        {
            return _context.Libros.ToList();
        }

        public List<Libro> GetLibro(string? stock = null, string? autor = null, string? titulo = null)
        {
            return _context.Libros.
                                    Where(libro => (string.IsNullOrEmpty(stock) || libro.Autor == autor) &&
                                    (string.IsNullOrEmpty(autor) || libro.Autor == autor) &&
                                    (string.IsNullOrEmpty(titulo) || libro.Titulo == titulo)).ToList();
        }

        public Libro GetLibroByIsbn(string isbn)
        {
            return _context.Libros.SingleOrDefault(libro => libro.ISBN == isbn);
        }       

        public void Add(Libro libro)
        {
            _context.Add(libro);
            _context.SaveChanges();
        }

        public void Update(Libro libro)
        {
            _context.Update(libro);
            _context.SaveChanges();
        }

        public void Delete(Libro libro)
        {
            _context.Remove(libro);
            _context.SaveChanges();
        }

        public void DeleteByIsbn(string isbn)
        {
            Delete(GetLibroByIsbn(isbn));
        }
    }
}
