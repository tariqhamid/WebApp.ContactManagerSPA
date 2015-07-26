using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.ContactManagerSPA.Models;

namespace WebApp.ContactManagerSPA.Services
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetContactsList();
        Contact GetContact(string id);
        Response UpdateContact(string id, Contact contact);
        Response PostContact(Contact contact);
    }
}
