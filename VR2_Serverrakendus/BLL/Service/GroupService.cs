using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GroupService
    {
        private readonly IGroupRepository _repo;
        private readonly GroupDTOFactory _groupDtoFactory;

        public GroupService()
        {
            this._repo = new GroupRepository(new PhoneBookDbContext());
            this._groupDtoFactory = new GroupDTOFactory();
        }

        public List<GroupDTO> GetGroupByLastName(string groupname)
        {
            return _repo.All.Where(x => x.GroupName == groupname)
                .ToList().Select(x => _groupDtoFactory.CreateBasicDTO(x)).ToList();
        }
        public List<GroupDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _groupDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public GroupDTO GetById(int groupId)
        {
            Group group = _repo.GetById(groupId);
            return _groupDtoFactory.CreateBasicDTO(group);
        }
        public void Add(Group newGroup)
        {
            _repo.Add(newGroup);
            _repo.SaveChanges();
        }

        public void Delete(int favoriteId)
        {
            _repo.Delete(favoriteId);
            _repo.SaveChanges();
        }

        public void Update(Group newgGroup)
        {
            _repo.Update(newgGroup);
            _repo.SaveChanges();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }


    }
}
