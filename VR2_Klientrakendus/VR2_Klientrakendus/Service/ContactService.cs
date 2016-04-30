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
    public class ContactService : BaseService, IContactService
    {


        public ContactService() :base (ServiceConstants.ContactServiceUrl)
        {

        }

        public async Task<ObservableCollection<Contact>> GetAll()
        {
            return await base.GetData<ObservableCollection<Contact>>("");
        }

        public async Task<Contact> GetById(int contactId)
        {
            return await base.GetData<Contact>("/" + contactId);
        }

        public async Task<Contact> Add(Contact contact)
        {
            return await base.PostData(contact);
        }

        public async Task<Contact> Update(Contact contact, int contactId)
        {
            return await base.PutData(contact, contactId);
        }

        public async Task<Contact> Delete(int contactId)
        {
            return await base.DeleteData<Contact>(contactId);
        }
    }
}
