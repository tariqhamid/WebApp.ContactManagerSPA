﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public interface IAccountsRepository
    {
        Account GetAccount(string email);
        Response RegisterCouchDbAccount(Account account);
    }
}
