using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Repository
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetCouchDBContacts();
        Contact GetCouchDBContact(string id);
        Response UpdateCouchDbContact(string id, Contact contact);
    }
}
