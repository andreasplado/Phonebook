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
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace WebApi.Controllers
{
    public class GroupsController : ApiController
    {
        //private PhoneBookDbContext db = new PhoneBookDbContext();
        private readonly GroupService _groupService;

        public GroupsController()
        {
            _groupService = new GroupService();
        }

        // GET: api/Groups
        public IHttpActionResult GetGroups()
        {
            List<GroupDTO> groups = _groupService.GetAll();
            if (groups == null)
            {
                return NotFound();
            }

            return Ok(groups);
        }

        // GET: api/Groups/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult GetGroup(int id)
        {
            GroupDTO group = _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [ResponseType(typeof(Group))]
        [HttpGet]
        [Route("api/Groups/getbygroupname/{groupname}")]
        public IHttpActionResult GetByGroupByName(string groupname)
        {
            List<GroupDTO> group = _groupService.GetGroupByLastName(groupname);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);

        }

        // PUT: api/Groups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroup([FromBody]Group group, [FromUri]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.GroupId)
            {
                return BadRequest();
            }

            _groupService.Update(group);

            try
            {

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        [ResponseType(typeof(Group))]
        public IHttpActionResult PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _groupService.Add(group);

            return CreatedAtRoute("DefaultApi", new { id = group.GroupId }, group);
        }

        // DELETE: api/Groups/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult DeleteGroup(int id)
        {
            GroupDTO group = _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }
            _groupService.Delete(id);

            return Ok(group);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _groupService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupExists(int id)
        {
            return _groupService.GetAll().Count(e => e.GroupId == id) > 0;
        }
    }
}