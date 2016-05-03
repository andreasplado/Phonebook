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
using BLL.Service;
using DAL;
using DAL.Repositories;
using Domain;

namespace WebApi.Controllers
{
    public class ContactTypesController : ApiController
    {

        private readonly ContactTypeService _contactTypeService;

        public ContactTypesController()
        {
            _contactTypeService = new ContactTypeService();
        }

        // GET: api/ContactTypes
        public IHttpActionResult GetContactTypes()
        {

            List<ContactTypeDTO> contactTypes = _contactTypeService.GetAll();
            if (contactTypes == null)
            {
                return NotFound();
            }
            return Ok(contactTypes);
        }

        // GET: api/ContactTypes/5
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult GetContactType(int id)
        {
            ContactTypeDTO contactType = _contactTypeService.GetById(id);
            if (contactType == null)
            {
                return NotFound();
            }

            return Ok(contactType);
        }

        // PUT: api/ContactTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactType([FromBody]ContactType contactType, [FromUri]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactType.ContactTypeId)
            {
                return BadRequest();
            }

            _contactTypeService.Update(contactType);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContactTypes
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult PostContactType(ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contactTypeService.Add(contactType);


            return CreatedAtRoute("DefaultApi", new { id = contactType.ContactTypeId }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [ResponseType(typeof(ContactType))]
        public IHttpActionResult DeleteContactType(int id)
        {
            ContactTypeDTO contactType = _contactTypeService.GetById(id);
            if (contactType == null)
            {
                return NotFound();
            }
            else
            {
                _contactTypeService.Delete(id);

                return Ok(contactType);
            }


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactTypeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactTypeExists(int id)
        {
            return _contactTypeService.GetAll().Count(e => e.ContactTypeId == id) > 0;
        }
    }
}