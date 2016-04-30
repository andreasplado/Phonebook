using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL;
using DAL.Repositories;
using Domain;

namespace WebApi.Controllers
{
    public class ContactInGroupsController : ApiController
    {
        //private PhoneBookDbContext db = new PhoneBookDbContext();

        private readonly ContactInGroupService _contactInGroupService;

        public ContactInGroupsController()
        {
            _contactInGroupService = new ContactInGroupService();
        }
        // GET: api/ContactInGroups
        public IHttpActionResult GetContactInGroups()
        {
            var contactInGroup = _contactInGroupService.GetAll();
            return Ok(contactInGroup);
        }

        // GET: api/ContactInGroups/5
        [ResponseType(typeof(ContactInGroup))]
        public IHttpActionResult GetContactInGroup(int id)
        {
            ContactInGroupDTO contactInGroup = _contactInGroupService.GetById(id);
            if (contactInGroup == null)
            {
                return NotFound();
            }

            return Ok(contactInGroup);
        }

        // PUT: api/ContactInGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactInGroup(int id, ContactInGroup contactInGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactInGroup.ContactInGroupId)
            {
                return BadRequest();
            }

            _contactInGroupService.Update(contactInGroup);

            try
            {

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContactInGroups
        [ResponseType(typeof(ContactInGroup))]
        public IHttpActionResult PostContactInGroup(ContactInGroup contactInGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contactInGroupService.Add(contactInGroup);

            return CreatedAtRoute("DefaultApi", new { id = contactInGroup.ContactInGroupId }, contactInGroup);
        }

        // DELETE: api/ContactInGroups/5
        [ResponseType(typeof(ContactInGroup))]
        public IHttpActionResult DeleteContactInGroup(int id)
        {
            ContactInGroupDTO contactInGroup = _contactInGroupService.GetById(id);
            if (contactInGroup == null)
            {
                return NotFound();
            }

            _contactInGroupService.Delete(id);

            return Ok(contactInGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactInGroupService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactInGroupExists(int id)
        {
            return _contactInGroupService.GetAll().Count(e => e.ContactInGroupId == id) > 0;
        }
    }
}