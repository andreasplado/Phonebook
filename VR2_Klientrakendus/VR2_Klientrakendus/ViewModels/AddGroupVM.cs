using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;

namespace VR2_Klientrakendus.ViewModels
{
    public class AddGroupVM
    {
        public void AddGroup(Group newGroup)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21855/api/Groups");
            HttpResponseMessage response = client.PostAsJsonAsync("", newGroup).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
