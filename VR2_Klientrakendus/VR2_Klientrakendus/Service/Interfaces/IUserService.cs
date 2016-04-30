using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;

namespace VR2_Klientrakendus.Service.Interfaces
{
    public interface IUserService
    {
        Task<ObservableCollection<User>> GetAll();
        Task<User> GetById(int userId);
        Task<User> Add(User user);
        Task<User> Update(User user, int userId);
        Task<User> Delete(int userId);
        Task<ObservableCollection<User>> GetBySearchQuery(string searchQuery);
    }
}
