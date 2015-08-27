using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public interface IAccountsRepository
    {
        Response LoginCouchDbAccount(string username, string password);
        Response RegisterCouchDbContact(Account account);
    }
}
