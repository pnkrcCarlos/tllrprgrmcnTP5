using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2.AccountManager.Domain
{
    class Account
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double OverdraftLimit { get; set; }
        public Client Client { get; set; }
        public IList<AccountMovement> Movements = new List<AccountMovement>();

        public double GetBalance() {
            double balance = 0;
            foreach (AccountMovement am in Movements)
            {
                balance += am.Amount;
            }
            return balance;
        }

        public IEnumerable<AccountMovement> GetLastMovements(int pCount = 7)
        {
            List<AccountMovement> last = (List<AccountMovement>)Movements.OrderByDescending(m => m.Date);
            return last.Take(pCount);
        }
    }
}
