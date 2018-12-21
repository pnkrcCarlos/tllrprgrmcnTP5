using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2
{
    class Movimiento
    {
        public int MovimientoId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public String Descripcion { get; set; }
        public float Monto { get; set; }
    }
}
