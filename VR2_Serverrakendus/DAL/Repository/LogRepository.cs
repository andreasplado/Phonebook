using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class LogRepository: EFRepository<Log>, ILogRepository
    {
        public LogRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Log> GetLogByDescription(string description)
        {
            return All.Where(x => x.Description == description).ToList();
        }
    }
}
