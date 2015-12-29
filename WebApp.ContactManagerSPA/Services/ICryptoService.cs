using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.ContactManagerSPA.Services
{
    public interface ICryptoService
    {
        string GenerateSalt(int saltLength);
        string CreateSHAHash(string password, string salt);
    }
}
