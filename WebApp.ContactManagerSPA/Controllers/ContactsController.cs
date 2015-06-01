using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.ContactManagerSPA.Infrastructure;
using WebApp.ContactManagerSPA.Models;
using WebApp.ContactManagerSPA.Services;

namespace WebApp.ContactManagerSPA.Controllers
{
    public class ContactsController : ApiController
    {
        private IContactsService contactsService;
        private static readonly ILogAdapter logger;
        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        //GET api/Contacts/{id}
        [HttpGet]
        public IHttpActionResult GetContactBy(string id)
        {
            var contact = contactsService.GetContact(id);
            return Ok(contact);
        }

        //GET api/Contacts
        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            var conts = contactsService.GetContactsList();
            return Ok(conts);

            
        }

        //PUT api/Contact/{id}
        [HttpPut]
        public IHttpActionResult UpdateContact(string id, [FromBody]Contact contact)
        {
            var result = contactsService.UpdateContact(id, contact);
            return Ok(result);
        }
    }
}
