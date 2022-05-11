using System;
using TP2_REST_AccesData.Data;
using TP2_REST_Domain.Commands;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_AccesData.Commands
{
    public class LibrosRepository : ILibrosRepository
    {
        private readonly LibreriaDbContext _context;
        private readonly ILibrosRepository _librosRepository;

        public LibrosRepository(LibreriaDbContext context, 
            ILibrosRepository librosRepository)
        {
            _context = context;
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
            return _librosRepository.GetLibroByTitulo(titulo);
        }

        public List<Libro> GetLibros(bool stock, string autor, string titulo)
        {
            return _context.Libros.ToList();
        }
    }
}
