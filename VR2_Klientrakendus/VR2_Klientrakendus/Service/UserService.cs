using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service.Interfaces;

namespace VR2_Klientrakendus.Service
{
    public class UserService : BaseService, IUserService
    {

        public UserService() :base (ServiceConstants.UserServiceUrl)
        { 
        }

        public async Task<ObservableCollection<User>> GetAll()
        {
            return await base.GetData<ObservableCollection<User>>(ServiceConstants.UserServiceUrl);
        }

        public async Task<User> GetById(int userId)
        {
            return await base.GetData<User>(ServiceConstants.UserServiceUrl +"/" + userId);
        }

        public async Task<User> Add(User user)
        {
            return await base.PostData(user);
        }

        public async Task<User> Update(User user, int userId)
        {
            return await base.PutData(user, userId);
        }

        public async Task<User> Delete(int userId)
        {
            return await base.DeleteData<User>(userId);
        }

        public async Task<ObservableCollection<User>> GetBySearchQuery(string searchQuery)
        {
            return await base.GetData<ObservableCollection<User>>(ServiceConstants.UserServiceUrl + "/" + searchQuery);
        }

    }
}
