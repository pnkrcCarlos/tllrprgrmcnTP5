using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2.AccountManager.DAL
{
    interface IUnitOfWork : IDisposable
    {
        void Complete();
        IAccountRepository AccountRepository { get; }
        IClientRepository ClientRepository { get; }
    }
}
