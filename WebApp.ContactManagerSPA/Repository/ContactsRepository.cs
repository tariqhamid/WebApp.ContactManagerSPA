using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebApp.ContactManagerSPA.DAL;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public class ContactsRepository:IContactsRepository
    {
        CouchDB db = new CouchDB(ConfigurationManager.ConnectionStrings["couchdb"].ConnectionString);

        public Contact GetCouchDBContact(string id)
        {
            Contact contact = new Contact();
            string baseUri = db.couchDbConnection;
            string json = db.CouchDbRequest(baseUri + "/" + id);
            JObject jObject = JObject.Parse(json);
            contact = JsonConvert.DeserializeObject<Contact>(jObject.ToString());
            return contact;
        }
        public IEnumerable<Contact> GetCouchDBContacts()
        {
            List<Contact> ContactsList = new List<Contact>();
            string baseUri = db.couchDbConnection;
            string json = db.CouchDbRequest(baseUri + "/_design/contacts/_view/contacts"); 
            JObject jObject = JObject.Parse(json);
            foreach (var val in jObject["rows"])
            {
                var yourObject = JsonConvert.DeserializeObject<Contact>(val["value"].ToString());
                ContactsList.Add(yourObject);
            }

            return ContactsList;
        }

        public Response UpdateCouchDbContact(string id, Contact contact)
        {
            string data = JsonConvert.SerializeObject(contact, Formatting.None);
            string result = db.CouchDbPost(JObject.Parse(data).ToString());
            Response resp = JsonConvert.DeserializeObject<Response>(result);
            return resp;
        }
    }
}