using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class LogService
    {
        private readonly ILogRepository _repo;
        private readonly LogDTOFactory _logDtoFactory;

        public LogService()
        {
            this._repo = new LogRepository(new PhoneBookDbContext());
            this._logDtoFactory = new LogDTOFactory();
        }

        public List<LogDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _logDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public LogDTO GetById(int logId)
        {
            Log log = _repo.GetById(logId);
            return _logDtoFactory.CreateBasicDTO(log);
        }
        public void Add(Log newLog)
        {
            _repo.Add(newLog);
            _repo.SaveChanges();
        }

        public void Delete(int logId)
        {
            _repo.Delete(logId);
            _repo.SaveChanges();
        }

        public void Update(Log newLog)
        {
            _repo.Update(newLog);
            _repo.SaveChanges();
        }
        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
