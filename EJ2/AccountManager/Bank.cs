using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ2.AccountManager.IO;
using EJ2.AccountManager.DAL.EntityFramework;
using EJ2.AccountManager.Domain;

namespace EJ2.AccountManager
{
    // ControllerFacade
    class Bank
    {
        public IEnumerable<AccountDTO> GetClientAccounts(int pClientId)
        {
            List<AccountDTO> clientAccounts = new List<AccountDTO>();

            using (UnitOfWork uow = new UnitOfWork(new AccountManagerDbContext()))
            {
                Client client = uow.ClientRepository.Get(pClientId);

                foreach (Account account in client.Accounts)
                {
                    clientAccounts.Add(new AccountDTO
                    {
                        Balance = account.GetBalance(),
                        Id = account.Id,
                        Name = account.Name,
                        OverdraftLimit = account.OverdraftLimit
                    });
                }

                uow.Complete();
            }

            return clientAccounts;
        }

        public IEnumerable<AccountMovementDTO> GetAccountMovements(int pAccountId)
        {
            List<AccountMovementDTO> accountMovements = new List<AccountMovementDTO>();

            using (UnitOfWork uow = new UnitOfWork(new AccountManagerDbContext()))
            {
                Account account = uow.AccountRepository.Get(pAccountId);

                foreach (AccountMovement movement in account.Movements)
                {
                    accountMovements.Add(new AccountMovementDTO()
                    {
                        Amount = movement.Amount,
                        Id = movement.Id,
                        Date = movement.Date,
                        Description  = movement.Description
                    });
                }

                uow.Complete();
            }

            return accountMovements;
        }

        public void NewAccount(int pClientId, String pAccountName, double pOverdraftLimit)
        {
            using (UnitOfWork uow = new UnitOfWork(new AccountManagerDbContext()))
            {
                Account account = new Account
                {
                    Id = 1,
                    Name = pAccountName,
                    OverdraftLimit = pOverdraftLimit,
                    Client = uow.ClientRepository.Get(pClientId)
                };

                uow.AccountRepository.Add(account);
                uow.Complete();
            }
        }

        public void NewAccountMovement(int pAccountId, double pAmount, String pDescription)
        {
            using (UnitOfWork uow = new UnitOfWork(new AccountManagerDbContext()))
            {
                AccountMovement movement = new AccountMovement
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Description = pDescription,
                    Amount = pAmount
                };

                Account account = uow.AccountRepository.Get(pAccountId);
                account.Movements.Add(movement);

                uow.Complete();
            }
        }

        public Client GetClientData(int pClientId)
        {
            Client client = new Client();

            using (UnitOfWork uow = new UnitOfWork(new AccountManagerDbContext()))
            {
                client = uow.ClientRepository.Get(pClientId);
            }

            return client;
        }
    }
}
