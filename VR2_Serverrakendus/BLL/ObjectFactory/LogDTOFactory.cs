using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class LogDTOFactory
    {
        public LogDTO CreateBasicDTO(Log log)
        {
            return new LogDTO()
            {
                LogId = log.LogId,
                Description = log.Description,
                Added = log.Added,
                Deleted = log.Deleted,
                Updated = log.Updated
            };
        }
    }
}
