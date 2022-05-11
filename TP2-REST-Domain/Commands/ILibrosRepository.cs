using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Domain.Commands
{
    public interface ILibrosRepository
    {
        List<Libro> GetLibros(bool stock, string autor, string titulo);
        Libro GetLibroByStock(bool stock);
        Libro GetLibroByAutor(string autor);
        Libro GetLibroByTitulo(String titulo);
    }
}
