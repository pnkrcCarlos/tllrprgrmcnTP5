using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2.AccountManager.Domain
{
    class AccountMovement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public double Amount { get; set; }
    }
}
