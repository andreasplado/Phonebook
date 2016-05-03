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
    public class UsersController : ApiController
    {
        private readonly UserService _userService;


        public UsersController()
        {
            _userService = new UserService();
        }

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            List<UserDTO> users = _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            UserDTO user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/getbyfirstname/Peeter
        [ResponseType(typeof(User))]
        [HttpGet]
        [Route("api/Users/getbyfirstname/{firstname}")]
        public IHttpActionResult GetUserByFirstName(string firstname)
        {
            List<BLL.DTO.UserDTO> user = _userService.GetUserByFirstName(firstname);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/getbylastname/Pakiraam
        [ResponseType(typeof(User))]
        [HttpGet]
        [Route("api/Users/getbylastname/{lastname}")]
        public IHttpActionResult GetUserByLastName(string lastname)
        {
            List<BLL.DTO.UserDTO> user = _userService.GetUserByLastName(lastname);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser([FromBody]User user, [FromUri]int id)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.AddUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            UserDTO user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUse(id);

            return Ok(user);
        }

        // DELETE: api/Users/UKKUY
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string firstName)
        {
            List<UserDTO> users = _userService.GetUserByFirstName(firstName);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userService.UserRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return _userService.UserRepository.All.Count(e => e.UserId == id) > 0;
        }
    }
}