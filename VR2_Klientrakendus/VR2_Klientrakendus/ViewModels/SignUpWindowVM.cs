using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service;

namespace VR2_Klientrakendus.ViewModels
{
    public class SignUpWindowVM
    {
        private UserService _userService;

        public SignUpWindowVM()
        {
            this._userService = new UserService();
        }

        public async void AddUser(User newUser)
        {
            await this._userService.Add(newUser);
        }
    }
}
