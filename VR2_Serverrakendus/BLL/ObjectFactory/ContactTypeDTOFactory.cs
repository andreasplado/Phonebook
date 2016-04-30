using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class ContactTypeDTOFactory
    {
        public ContactTypeDTOFactory()
        {
            
        }

        public ContactTypeDTO CreateBasicDTO(ContactType contactType)
        {
            return new ContactTypeDTO
            {
                ContactTypeId = contactType.ContactTypeId,
                ContactTypeValue = contactType.ContactTypeValue,
                Added = contactType.Added,
                Deleted = contactType.Deleted,
                Updated = contactType.Updated
            };
        }
    }
}
