using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using Domain;

namespace BLL.ObjectFactory
{
    public class UserDTOFactory
    {
        public UserDTOFactory()
        {
            
        }

        public UserDTO CreateBasicDTO(User user)
        {
            return new UserDTO
            {
                Age = user.Age,
                Email = user.Email,
                LastName = user.LastName,
                Name = user.Name,
                UserId = user.UserId,
                UserName = user.UserName,
                Added = user.Added,
                Deleted = user.Deleted,
                Updated = user.Updated
            };
        }
    }
}
