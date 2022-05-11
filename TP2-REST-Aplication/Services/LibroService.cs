using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Aplication.Services
{
    public interface ILibrosService
    {
        List<Libro> GetLibros(bool? stock, string autor, string titulo);
        Libro GetLibroByStock(bool stock);
        Libro GetLibroByAutor(string autor);
        Libro GetLibroByTitulo(String titulo);
    }
    public class LibroService : ILibrosService
    {
        private readonly ILibrosRepository _librosRepository;

        public LibroService(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        public Libro GetLibroByAutor(string autor)
        {
            return _librosRepository.GetLibroByAutor(autor);
        }

        public Libro GetLibroByStock(bool stock)
        {
            return _librosRepository.GetLibroByStock(stock);
        }

        public Libro GetLibroByTitulo(string titulo)
        {
            return _librosRepository.GetLibroByAutor(titulo);
        }

        public List<Libro> GetLibros(bool? stock, string autor, string titulo)
        {
            return _librosRepository.GetLibros(stock, autor, titulo);
        }
    }
}
