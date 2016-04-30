using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL;
using DAL.Interface;
using DAL.Repositories;
using DAL.Repository;
using Domain;

namespace BLL.Service
{
    public class UserInRoleService
    {
        private readonly IUserInRoleRepository _repo;
        private readonly UserInRoleDTOFactory _userInRoleDtoFactory;

        public UserInRoleService()
        {
            this._repo = new UserInRoleRepository(new PhoneBookDbContext());
            this._userInRoleDtoFactory = new UserInRoleDTOFactory();
        }

        public List<UserInRoleDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _userInRoleDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public UserInRoleDTO GetById(int userInRoleId)
        {
            UserInRole userInRole = _repo.GetById(userInRoleId);
            return _userInRoleDtoFactory.CreateBasicDTO(userInRole);
        }

        public void Add(UserInRole newuUserInRole)
        {
            _repo.Add(newuUserInRole);
        }

        public void Update(UserInRole newUserInRole)
        {
            _repo.Update(newUserInRole);
        }

        public void Delete(int userId)
        {
            _repo.Delete(userId);
        }
        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
