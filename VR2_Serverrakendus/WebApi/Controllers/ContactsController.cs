using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.ObjectFactory;
using BLL.Service;
using DAL;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly ContactService _contactService;

        public ContactsController()
        {
            _contactService = new ContactService();
        }

        // GET: api/Contacts
        public IHttpActionResult GetContacts()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            ContactDTO contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // GET: api/findcontactsbyname/Peeter
        [ResponseType(typeof(User))]
        [HttpGet]
        [Route("api/Contacts/getbyfirstname/{firstname}")]
        public IHttpActionResult GetContactByFirstName(string firstname)
        {
            List<BLL.DTO.ContactDTO> contacts = _contactService.GetContactsByFirstName(firstname);
            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // GET: api/Contacts/Pakiraam
        [ResponseType(typeof(User))]
        [HttpGet]
        [Route("api/Contacts/getbylastname/{lastname}")]
        public IHttpActionResult GetContactByLastName(string lastname)
        {
            List<BLL.DTO.ContactDTO> contacts = _contactService.GetContactsByLastName(lastname);
            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(Contact contact, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }

            _contactService.Update(contact);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lol = contact;
            _contactService.Add(contact);
            //_contactRepository.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            ContactDTO contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Delete(id);

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return _contactService.GetAll().Count(e => e.ContactId == id) > 0;
        }
    }
}