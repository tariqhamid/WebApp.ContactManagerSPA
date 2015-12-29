using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApp.ContactManagerSPA.DAL;
using WebApp.ContactManagerSPA.Infrastructure;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public class AccountsRepository:IAccountsRepository
    {
        CouchDB db = new CouchDB(ConfigurationManager.ConnectionStrings["couchdb"].ConnectionString);
        private ILogAdapter logger;
        public AccountsRepository(ILogAdapter logger)
        {
            this.logger = logger;
        }
        
        public Response RegisterCouchDbAccount(Account account)
        {
            string data = JsonConvert.SerializeObject(account, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string result = db.CouchDbPost(JObject.Parse(data).ToString());
            Response response = JsonConvert.DeserializeObject<Response>(result);
            return response;
        }

        public Account GetAccount(string email)
        {
            List<Account> accountsList = new List<Account>();
            try
            {
                string baseUri = db.couchDbConnection;
                string json = db.CouchDbRequest(baseUri + "/_design/user/_view/user");
                JObject jObject = JObject.Parse(json);
                foreach (var val in jObject["rows"])
                {
                    var accountObject = JsonConvert.DeserializeObject<Account>(val["value"].ToString());
                    accountsList.Add(accountObject);
                }
            }
            catch
            {
                logger.Log(LoggingLevel.Error, "Unable to connect with couchdb");
                return null;
            }
            return accountsList.Find(e => e.Email.Equals(email));
        }
    }
}