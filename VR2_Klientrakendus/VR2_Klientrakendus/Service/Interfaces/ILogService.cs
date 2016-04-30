using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;

namespace VR2_Klientrakendus.Service.Interfaces
{
    public interface ILogService
    {
        Task<ObservableCollection<Log>> GetAll();
        Task<Log> GetById(int groupId);
        Task<Log> Add(Log log);
        Task<Log> Update(Log log, int logId);
        Task<Log> Delete(int logId);
    }
}
