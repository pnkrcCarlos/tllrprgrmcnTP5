using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ2.AccountManager.DAL.EntityFramework
{
    class AccountManagerDbContext : DbContext
    {
        public DbSet Clients { get; set; }
        public DbSet Accounts { get; set; }
        public DbSet AccountMovements { get; set; }
    }
}
