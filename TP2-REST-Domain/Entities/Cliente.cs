using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_REST_Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Alquileres = new HashSet<Alquiler>();
        }

        public int ClienteId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Alquiler> Alquileres { get; set; }
    }
}
