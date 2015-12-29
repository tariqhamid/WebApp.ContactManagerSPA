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
    public class UsersRepository:IUsersRepository
    {
        CouchDB db = new CouchDB(ConfigurationManager.ConnectionStrings["couchdb"].ConnectionString);
        private ILogAdapter logger;
        public UsersRepository(ILogAdapter logger)
        {
            this.logger = logger;
        }

        //public Account GetCouchDbAccountByEmail(string email)
        //{
        //    Account account = new Account();
        //    try
        //    {
        //        string baseUri = db.couchDbConnection;
        //        string json = db.CouchDbRequest(baseUri + "/_design/user/_view/user?key=\"" + email + "\"");
        //        JObject accountObject = JObject.Parse(json);
        //        account = JsonConvert.DeserializeObject<Account>(accountObject.Last.Last.First.Last.Last.ToString());

        //    }
        //    catch
        //    {
        //        logger.Log(LoggingLevel.Error, "There was an error while trying to load account with email" + email);
        //        return null;
        //    }
        //    return account;
        //}
    }
}