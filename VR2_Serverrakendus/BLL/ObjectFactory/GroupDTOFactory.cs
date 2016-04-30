using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class GroupDTOFactory
    {
        public GroupDTOFactory()
        {
            
        }

        public GroupDTO CreateBasicDTO(Group group)
        {
            return new GroupDTO()
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                Description = group.Description,
                Added = group.Added,
                Deleted = group.Deleted,
                Updated = group.Updated
            };
        }
    }
}
