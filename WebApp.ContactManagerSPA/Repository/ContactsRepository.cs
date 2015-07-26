using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebApp.ContactManagerSPA.DAL;
using WebApp.ContactManagerSPA.Infrastructure;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public class ContactsRepository:IContactsRepository
    {
        //CouchDB db = new CouchDB(ConfigurationManager.ConnectionStrings["couchdb"].ConnectionString);
        CouchDB db = new CouchDB("http://vasileios:vasileios@127.0.0.1:5984/contactsdb");
        private ILogAdapter logger;
        public ContactsRepository(ILogAdapter logger){
            this.logger = logger;
        }

        public Contact GetCouchDBContact(string id)
        {
            Contact contact = new Contact();
            try
            {
                string baseUri = db.couchDbConnection;
                string json = db.CouchDbRequest(baseUri + "/" + id);
                JObject jObject = JObject.Parse(json);
                contact = JsonConvert.DeserializeObject<Contact>(jObject.ToString());

            }
            catch
            {
                logger.Log(LoggingLevel.Error, "There was an error while trying to load contact with id" + id);
                return null;
            }
            return contact;
        }
        public IEnumerable<Contact> GetCouchDBContacts()
        {
            List<Contact> contactsList = new List<Contact>();
            try
            {
                string baseUri = db.couchDbConnection;
                string json = db.CouchDbRequest(baseUri + "/_design/contacts/_view/contacts");
                JObject jObject = JObject.Parse(json);
                foreach (var val in jObject["rows"])
                {
                    var yourObject = JsonConvert.DeserializeObject<Contact>(val["value"].ToString());
                    contactsList.Add(yourObject);
                }
            }
            catch
            {
                logger.Log(LoggingLevel.Error, "Unable to connect with couchdb");
                return null;
            }
            return contactsList;
        }

        public Response UpdateCouchDbContact(string id, Contact contact)
        {
            string data = JsonConvert.SerializeObject(contact, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string result = db.CouchDbPost(JObject.Parse(data).ToString());
            Response resp = JsonConvert.DeserializeObject<Response>(result);
            return resp;
        }

        public Response PostCouchDbContact(Contact contact)
        {
            string data = JsonConvert.SerializeObject(contact, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            
            string result = db.CouchDbPost(JObject.Parse(data).ToString());
            Response resp = JsonConvert.DeserializeObject<Response>(result);
            return resp;
        }
    }
}