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
                JObject contactObject = JObject.Parse(json);
                contact = JsonConvert.DeserializeObject<Contact>(contactObject.ToString());

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
                    var contactObject = JsonConvert.DeserializeObject<Contact>(val["value"].ToString());
                    contactsList.Add(contactObject);
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
            Response response = JsonConvert.DeserializeObject<Response>(result);
            return response;
        }

        public Response PostCouchDbContact(Contact contact)
        {
            string data = JsonConvert.SerializeObject(contact, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            
            string result = db.CouchDbPost(JObject.Parse(data).ToString());
            Response response = JsonConvert.DeserializeObject<Response>(result);
            return response;
        }

        public Response DeleteCouchDbContact(string id, string rev)
        {
            string result = db.CouchDbDelete(id, rev);
            Response response = JsonConvert.DeserializeObject<Response>(result);
            return response;
        }
    }
}