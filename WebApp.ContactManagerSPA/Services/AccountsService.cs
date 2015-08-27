using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebApp.ContactManagerSPA.Models;
using WebApp.ContactManagerSPA.Repository;

namespace WebApp.ContactManagerSPA.Services
{
    public class AccountsService:IAccountsService
    {
        private readonly IAccountsRepository accountRepository;

        public AccountsService(IAccountsRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Response LoginAccount(string username, string password)
        {
            return accountRepository.LoginCouchDbAccount(username, password);
        }

        public Response RegisterAccount(Account account)
        {
            account.Id = "org.couchdb.user:" + account.Email.Split('@')[0];
            account.Salt = GenerateSalt(32);
            account.PasswordHash = CreateSHAHash(account.Password, account.Salt);
            return accountRepository.RegisterCouchDbContact(account);
        }

        private string GenerateSalt(int saltLength)
        {
            var salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        private string CreateSHAHash(string Password, string Salt)
        {
            string saltAndPwd = String.Concat(Password, Salt);
            SHA256 algorithm = SHA256.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPwd));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2");
            }
            return sh1;
        }

    }
}