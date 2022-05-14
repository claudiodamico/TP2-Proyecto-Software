using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface ILibrosRepository
    {
        List<Libro> GetAllLibros();
        Libro GetLibrosByStock(bool? stock);
        Libro GetLibrosByAutor(string autor);
        Libro GetLibrosByTitulo(string titulo);
    }
}
