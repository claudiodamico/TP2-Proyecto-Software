using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_REST_Domain.Entities
{
    public class EstadoDeAlquiler
    {
        public EstadoDeAlquiler()
        {
            Alquileres = new HashSet<Alquiler>();
        }

        public int EstadoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Alquiler> Alquileres { get; set; }
    }
}
