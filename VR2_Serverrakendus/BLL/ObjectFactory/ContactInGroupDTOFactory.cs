using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class ContactInGroupDTOFactory
    {

        public ContactInGroupDTOFactory()
        {
            
        }

        public ContactInGroupDTO CreateBasicDTO(ContactInGroup contactInGroup)
        {
            return new ContactInGroupDTO()
            {
                ContactInGroupId = contactInGroup.ContactInGroupId,
                ContactId = contactInGroup.ContactId,
                GroupId = contactInGroup.GroupId,
                Added = contactInGroup.Added,
                Deleted = contactInGroup.Deleted,
                Updated = contactInGroup.Updated
            };
        }

    }
}
