using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;

namespace VR2_Klientrakendus.ViewModels
{
    public class UserProfileVM
    {
        private User _user;
        public User User
        {
            get { return this._user; }
        }
        public void LoadUserById(int userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21855/api/Users/" + userId);
            HttpResponseMessage response = client.GetAsync("").Result;
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsAsync<User>().Result;
            _user = result;
        }

        public void UpdateUser(User user, int userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21855/api/Users/" + userId);

            var resp = client.PutAsJsonAsync<User>("", user).Result;
            if (resp.StatusCode == HttpStatusCode.NotFound)
            {

            }

        }

        public void DeleteUser(int userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21855/api/Users/" + userId);
            var resp = client.DeleteAsync("http://localhost:21855/api/Users/" + userId);

        }
    }
}
