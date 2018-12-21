﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ2.AccountManager.Domain;

namespace EJ2.AccountManager.DAL.EntityFramework
{
    class ClientRepository : Repository<Client, AccountManagerDbContext>, IClientRepository
    {
        public ClientRepository(AccountManagerDbContext pContext) : base(pContext) { }
    }
}