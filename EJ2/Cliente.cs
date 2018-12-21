using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2
{
    class Cliente
    {
        public int ClienteId { get; set; }
        public String Dni { get; set; }
        public String Apellido { get; set; }
        public String Nombre { get; set; }
        public IDictionary<String, Cuenta> Cuentas { get; set; }
    }
}
