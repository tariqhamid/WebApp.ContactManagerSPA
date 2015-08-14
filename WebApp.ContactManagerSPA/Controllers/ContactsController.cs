using AutoMapper;
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
    [RoutePrefix("api/Contacts")]
    public class ContactsController : ApiController
    {
        private IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        //GET api/Contacts/{id}
        [HttpGet]
        public IHttpActionResult GetContactBy(string id)
        {
            //logger.Log(LoggingLevel.Debug, "message");
            var contact = contactsService.GetContact(id);
            if (contact == null)
            {
                return BadRequest("okoko");
            }
            return Ok(contact);
        }

        //GET api/Contacts
        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            var contacts = contactsService.GetContactsList();
            if (contacts == null)
            {
                return BadRequest("dsfafdfsa");
            }
            return Ok(contacts);
            
        }

        //PUT api/Contacts/{id}
        [HttpPut]
        public IHttpActionResult UpdateContact(string id, [FromBody]Contact contact)
        {
            var result = contactsService.UpdateContact(id, contact);
            return Ok(result);
        }

        // POST api/Contacts
        [HttpPost]
        public IHttpActionResult AddContact([FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = contactsService.PostContact(contact);
            return Ok(result);
        }

        [HttpDelete]
        // DELETE api/Contact/{id}
        public IHttpActionResult DeleteContact(string id, string rev)
        {
            var result = contactsService.DeleteContact(id, rev);
            return Ok(result);
        }
    }
}
