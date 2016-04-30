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
    public class ContactInGroupService : BaseService, IContactInGroupService

    {

        public ContactInGroupService() : base(ServiceConstants.ContactInGroupServiceUrl)
        {

        }
        public async Task<ObservableCollection<ContactInGroup>> GetAll()
        {
            return await base.GetData<ObservableCollection<ContactInGroup>>("");
        }

        public async Task<ContactInGroup> GetById(int contactId)
        {
            return await base.GetData<ContactInGroup>("/" + contactId);
        }

        public async Task<ContactInGroup> Add(ContactInGroup contact)
        {
            return await base.PostData(contact);
        }

        public async Task<ContactInGroup> Update(ContactInGroup contact, int contactId)
        {
            return await base.PutData(contact, contactId);
        }

        public async Task<ContactInGroup> Delete(int contactId)
        {
            return await base.DeleteData<ContactInGroup>(contactId);
        }
    }
}
