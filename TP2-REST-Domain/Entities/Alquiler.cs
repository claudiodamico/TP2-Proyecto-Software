
namespace TP2_REST_Domain.Entities
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string ISBN { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public virtual Cliente ClienteNavigation { get; set; }
        public virtual EstadoDeAlquiler EstadoNavigation { get; set; }
        public virtual Libro IsbnNavigation { get; set; }
    }
}
