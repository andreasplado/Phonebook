using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class UserService
    {

        private readonly IUserRepository _repo;
        private readonly UserDTOFactory _userDtoFactory;
        public UserRepository UserRepository;

        public UserService()
        {
            this._repo = new UserRepository(new PhoneBookDbContext());
            this._userDtoFactory = new UserDTOFactory();
            this.UserRepository = new UserRepository(new PhoneBookDbContext());
        }

        public List<UserDTO> GetUserByFirstName(string firstName)
        {
            return _repo.All.Where(x => x.Name == firstName)
                .ToList().Select(x => _userDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public List<UserDTO> GetUserByLastName(string lastname)
        {
            return _repo.All.Where(x => x.LastName == lastname)
                .ToList().Select(x => _userDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public List<UserDTO> GetAllUsers()
        {
            return _repo.All.ToList().Select(x => _userDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public UserDTO GetUserById(int userId)
        {
            User user = _repo.GetById(userId);
            return _userDtoFactory.CreateBasicDTO(user);
        }

        public void AddUser(User newuser)
        {
            _repo.Add(newuser);
            _repo.SaveChanges();
        }

        public void UpdateUser(User newUser)
        {
            _repo.Update(newUser);
            _repo.SaveChanges();
        }

        public void DeleteUse(int userId)
        {
            _repo.Delete(userId);
            _repo.SaveChanges();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }



    }
}
