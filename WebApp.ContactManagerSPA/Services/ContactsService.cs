using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ContactManagerSPA.Models;
using WebApp.ContactManagerSPA.Repository;

namespace WebApp.ContactManagerSPA.Services
{
    public class ContactsService:IContactsService
    {
        private readonly IContactsRepository contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        public IEnumerable<Contact> GetContactsList()
        {
            var contacts = contactsRepository.GetCouchDBContacts();
            return contacts;
        }

        public Contact GetContact(string id)
        {
            var contact = contactsRepository.GetCouchDBContact(id);
            return contact;
        }

        public Response UpdateContact(string id, Contact contact)
        {
            return contactsRepository.UpdateCouchDbContact(id, contact);
        }

        public Response PostContact(Contact contact)
        {
            return contactsRepository.PostCouchDbContact(contact);
        }
    }
}