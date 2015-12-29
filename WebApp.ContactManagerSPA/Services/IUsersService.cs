using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Services
{
    public interface IUsersService
    {
        Account LoginUser(string username, string password);
    }
}
