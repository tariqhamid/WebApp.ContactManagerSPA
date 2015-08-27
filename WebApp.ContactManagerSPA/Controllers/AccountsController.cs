using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.ContactManagerSPA.Models;
using WebApp.ContactManagerSPA.Services;

namespace WebApp.ContactManagerSPA.Controllers
{
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        private IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        //GET api/Accounts/{id}
        public IHttpActionResult GetAccount(string id)
        {
            return Ok();
        }

        //POST api/Accounts/Login
        public IHttpActionResult Login(string username, string password)
        {
            var result = accountsService.LoginAccount(username, password);
            return Ok(result);
        }

        //POST api/Accounts/Register
        public IHttpActionResult Register([FromBody]Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = accountsService.RegisterAccount(account);
            return Ok(result);
        }
    }
}
