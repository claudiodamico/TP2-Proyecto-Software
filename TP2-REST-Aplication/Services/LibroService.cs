using AutoMapper;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Aplication.Services
{
    public interface ILibrosService
    {
        List<Libro> GetAllLibros();
        List<LibroDto> GetLibro(string? stock = null, string? autor = null, string? titulo = null);
    }
    public class LibroService : ILibrosService
    {
        private readonly ILibrosRepository _librosRepository;
        private readonly IMapper _mapper;

        public LibroService(ILibrosRepository librosRepository,
            IMapper mapper)
        {
            _librosRepository = librosRepository;
            _mapper = mapper;
        }

        public List<Libro> GetAllLibros()
        {
            return _librosRepository.GetAllLibros().ToList();
        }

        public List<LibroDto> GetLibro(string? stock = null, string? autor = null, string? titulo = null)
        {
            var libros = _librosRepository.GetLibro(stock, autor, titulo);

            return _mapper.Map<List<LibroDto>>(libros);
        }
    }
}
