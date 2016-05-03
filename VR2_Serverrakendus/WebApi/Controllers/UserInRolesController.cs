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
using DAL.Interface;
using DAL.Repository;
using Domain;

namespace WebApi.Controllers
{
    public class UserInRolesController : ApiController
    {
        private readonly UserInRoleService _userInRoleService;

        public UserInRolesController()
        {
            _userInRoleService = new UserInRoleService();
        }

        // GET: api/UserInRoles
        public IHttpActionResult GetUserInRoles()
        {
            List<UserInRoleDTO> userInRoles = _userInRoleService.GetAll();
            if (userInRoles == null)
            {
                return NotFound();
            }
            return Ok(userInRoles);
        }

        // GET: api/UserInRoles/5
        [ResponseType(typeof(UserInRole))]
        public IHttpActionResult GetUserInRole(int id)
        {
            UserInRoleDTO userInRole = _userInRoleService.GetById(id);
            if (userInRole == null)
            {
                return NotFound();
            }

            return Ok(userInRole);
        }

        // PUT: api/UserInRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserInRole([FromBody]UserInRole userInRole, [FromUri]int id)
        {
            if (ModelState.IsValid)
            {
                _userInRoleService.Update(userInRole);
            }

            if (id != userInRole.UserId)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserInRoles
        [ResponseType(typeof(UserInRole))]
        public IHttpActionResult PostUserInRole(UserInRole userInRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userInRoleService.Add(userInRole);

            return CreatedAtRoute("DefaultApi", new { id = userInRole.UserInRoleId }, userInRole);
        }

        // DELETE: api/UserInRoles/5
        [ResponseType(typeof(UserInRole))]
        public IHttpActionResult DeleteUserInRole(int id)
        {
            UserInRoleDTO userInRole = _userInRoleService.GetById(id);
            if (userInRole == null)
            {
                return NotFound();
            }
            _userInRoleService.Delete(id);

            return Ok(userInRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userInRoleService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}