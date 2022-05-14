using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface ILibrosRepository
    {       
        List<Libro> GetAllLibros();
        List<Libro> GetLibro(string? stock = null, string? autor = null, string? titulo = null);
        Libro GetLibroByIsbn(string isbn);
        void Add(Libro libro);
        void Update(Libro libro);
        void Delete(Libro libro);
        void DeleteByIsbn(string Iisbn);       
    }
}
