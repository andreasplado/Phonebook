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
    public class ContactTypeService :BaseService ,IContactTypeService
    {

        public ContactTypeService() :base (ServiceConstants.ContactTypeServiceUrl)
        {
        }

        public async Task<ObservableCollection<ContactType>> GetAll()
        {
            return await base.GetData<ObservableCollection<ContactType>>(ServiceConstants.ContactTypeServiceUrl);
        }

        public async Task<ContactType> GetById(int contactId)
        {
            return await base.GetData<ContactType>(ServiceConstants.ContactTypeServiceUrl + "/" + contactId);
        }

        public async Task<ContactType> Add(ContactType contactType)
        {
            return await base.PostData(contactType);
        }

        public async Task<ContactType> Update(ContactType contactType, int contactTypeId)
        {
            return await base.PutData(contactType, contactTypeId);
        }

        public async Task<ContactType> Delete(int contactTypeId)
        {
            return await base.DeleteData<ContactType>(contactTypeId);
        }
    }
}
