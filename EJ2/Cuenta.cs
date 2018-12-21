using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2
{
    class Cuenta
    {
        public int CuentaId { get; set; }
        public String Nombre { get; set; }
        public float LimiteDescubierto { get; set; }
        public IList<Movimiento> Movimientos { get; set; }
    }
}
