using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class ContactDTOFactory
    {

        public ContactDTO CreateBasicDTO(Contact contact)
        {
            return new ContactDTO
            {
                ContactId = contact.ContactId,
                ContactLastName = contact.ContactLastName,
                ContactName = contact.ContactName,
                ContactValue = contact.ContactValue,
                Added = contact.Added,
                Deleted = contact.Deleted,
                Updated = contact.Updated
            };
        }
    }
}
