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
    public class LogsController : ApiController
    {
        private readonly LogService _logService;

        public LogsController()
        {
            _logService = new LogService();
        }


        // GET: api/Logs
        public IHttpActionResult GetLogs()
        {
            List<LogDTO> logs = _logService.GetAll();
            if (logs == null)
            {
                return NotFound();
            }
            return Ok(logs);
        }

        // GET: api/Logs/5
        [ResponseType(typeof(Log))]
        public IHttpActionResult GetLog(int id)
        {
            LogDTO log = _logService.GetById(id);
            if (log == null)
            {
                return NotFound();
            }

            return Ok(log);
        }

        // PUT: api/Logs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLog([FromBody]Log log, [FromUri]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != log.LogId)
            {
                return BadRequest();
            }

            _logService.Update(log);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Logs
        [ResponseType(typeof(Log))]
        public IHttpActionResult PostLog(Log log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logService.Add(log);

            return CreatedAtRoute("DefaultApi", new { id = log.LogId }, log);
        }

        // DELETE: api/Logs/5
        [ResponseType(typeof(Log))]
        public IHttpActionResult DeleteLog(int id)
        {
            LogDTO log = _logService.GetById(id);
            if (log == null)
            {
                return NotFound();
            }

            _logService.Delete(id);

            return Ok(log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _logService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogExists(int id)
        {
            return _logService.GetAll().Count(e => e.LogId == id) > 0;
        }
    }
}