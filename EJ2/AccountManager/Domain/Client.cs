using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2.AccountManager.Domain
{
    class Client
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Document Document { get; set; }
        public IList<Account> Accounts = new List<Account>();
    }
}
