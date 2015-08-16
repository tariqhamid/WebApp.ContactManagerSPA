using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.ContactManagerSPA.DAL;
using WebApp.ContactManagerSPA.Repository;
using WebApp.ContactManagerSPA.Services;
using WebApp.ContactManagerSPA.Infrastructure;

namespace WebApp.ContactManagerSPA.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IContactsRepository repo;
        IContactsService service;
        ILogAdapter logger;
        [TestInitialize]
        public void Init()
        {
            CouchDB db = new CouchDB("http://vasileios:vasileios@127.0.0.1:5984/contactsdb");
        }
        [TestMethod]
        public void TestMethod1()
        {
            //var contact = new ContactManagerSPA.Models.ContactViewModel();
            var contact = new ContactManagerSPA.Models.Contact();
            contact.Id = "4816c87159cd23eda78c2d091c006fe2";
            contact.Revision = "6-247dfe189bf72f621da79244cf1aff38";
            contact.FirstName = "Vasilis";
            contact.LastName = "Boukonis";
            contact.Type = "contact";
            contact.Mobile = "88888";
            contact.Telephone = "9999";
            contact.ContactType = "mycompany";
            contact.Email = "mail@mail.com";
            
            var serv = new ContactsService(repo);
            
            CouchDB db = new CouchDB("http://vasileios:vasileios@127.0.0.1:5984/contactsdb");
            var re = new ContactsRepository(logger);
            //re.UpdateCouchDbContact(id, contact);
            //re.PostCouchDbContact(contact);
            db.CouchDbPost(contact.ToString());
            
                
        }
    }
}
