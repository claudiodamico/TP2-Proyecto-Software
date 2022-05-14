using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Aplication.Services
{
    public interface ILibrosService
    {
        List<Libro> GetAllLibros();
    }
    public class LibroService : ILibrosService
    {
        private readonly ILibrosRepository _librosRepository;

        public LibroService(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        public Libro GetLibrosByStock(bool? stock)
        {
            return _librosRepository.GetLibrosByStock(stock.Value);
        }

        public Libro GetLibrosByAutor(string autor)
        {
            return _librosRepository.GetLibrosByAutor(autor);
        }
       
        public Libro GetLibrosByTitulo(string titulo)
        {
            return _librosRepository.GetLibrosByTitulo(titulo);
        }

        public List<Libro> GetAllLibros()
        {
            return _librosRepository.GetAllLibros().ToList();
        }
    }
}
