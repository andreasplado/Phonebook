using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service;

namespace VR2_Klientrakendus.ViewModels
{
    public class AddContactVM
    {
        private readonly ContactService _contactService;

        public AddContactVM()
        {
            this._contactService = new ContactService();
        }
        public async void AddContact(Contact newContact)
        {
            await this._contactService.Add(newContact);

        }
    }
}
