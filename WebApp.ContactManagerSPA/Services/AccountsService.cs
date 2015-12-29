using JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Net;
using System.Net.Http;
using WebApp.ContactManagerSPA.Models;
using WebApp.ContactManagerSPA.Repository;

namespace WebApp.ContactManagerSPA.Services
{
    public class AccountsService:IAccountsService
    {
        private readonly IAccountsRepository accountRepository;
        private readonly ICryptoService cryptoService;
        public AccountsService(ICryptoService cryptoService, IAccountsRepository accountRepository)
        {
            this.cryptoService = cryptoService;
            this.accountRepository = accountRepository;
        }

        public Response RegisterAccount(Account account)
        {
            Response response = new Response();
            account.Id = "org.couchdb.user:" + account.Email.Split('@')[0];
            account.Salt = cryptoService.GenerateSalt(32);
            account.PasswordHash = cryptoService.CreateSHAHash(account.Password, account.Salt);
            if (accountRepository.GetAccount(account.Email) == null)
            {
                response = accountRepository.RegisterCouchDbAccount(account);
            }
            else
            {
                //return Request.CreateResponse(HttpStatusCode.BadRequest, "User already exist.");
                response.Message = string.Format("Account with {0} already exists", account.Email);
            }
            return response;
        }
    }
}