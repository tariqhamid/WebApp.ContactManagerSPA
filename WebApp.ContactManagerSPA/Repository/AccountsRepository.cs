using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ContactManagerSPA.DAL;
using WebApp.ContactManagerSPA.Infrastructure;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public class AccountsRepository:IAccountsRepository
    {
        CouchDB db = new CouchDB("http://vasileios:vasileios@127.0.0.1:5984/contactsdb");
        private ILogAdapter logger;
        public AccountsRepository(ILogAdapter logger)
        {
            this.logger = logger;
        }

        Response IAccountsRepository.LoginCouchDbAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        Response IAccountsRepository.RegisterCouchDbContact(Account account)
        {
            string data = JsonConvert.SerializeObject(account, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string result = db.CouchDbPost(JObject.Parse(data).ToString());
            Response response = JsonConvert.DeserializeObject<Response>(result);
            return response;
        }
    }
}