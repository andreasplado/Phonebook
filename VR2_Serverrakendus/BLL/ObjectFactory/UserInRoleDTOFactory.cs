using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class UserInRoleDTOFactory
    {
        public UserInRoleDTO CreateBasicDTO(UserInRole userInRole)
        {
            return new UserInRoleDTO()
            {
               UserId = userInRole.UserId,
               UserInRoleId = userInRole.UserInRoleId,
               Added = userInRole.Added,
               Deleted = userInRole.Deleted,
               Updated = userInRole.Updated
            };
        }
    }
}
