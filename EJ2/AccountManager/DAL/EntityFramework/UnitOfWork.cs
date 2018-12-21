using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ2.AccountManager.DAL;

namespace EJ2.AccountManager.DAL.EntityFramework
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly AccountManagerDbContext iDbContext;

        public UnitOfWork(AccountManagerDbContext pContext)
        {
            if (pContext==null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }
            this.iDbContext = pContext;
        }

        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.iDbContext.Dispose();
        }

        public IAccountRepository AccountRepository { get; private set; }
        
        public IClientRepository ClientRepository { get; private set; }
    }
}
