using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2.AccountManager.IO
{
    class AccountDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double OverdraftLimit { get; set; }
        public double Balance { get; set; }
    }
}
