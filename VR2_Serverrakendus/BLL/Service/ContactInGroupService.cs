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
    public class ContactInGroupService
    {
        private readonly IContactInGroupRepository _repo;
        private readonly ContactInGroupDTOFactory _contactInGroupDtoFactory;

        public ContactInGroupService()
        {
            this._repo = new ContactInGroupRepository(new PhoneBookDbContext());
            this._contactInGroupDtoFactory = new ContactInGroupDTOFactory();
        }

        public List<ContactInGroupDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _contactInGroupDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public ContactInGroupDTO GetById(int contactInGroupId)
        {
            ContactInGroup contactInGroup = _repo.GetById(contactInGroupId);
            return _contactInGroupDtoFactory.CreateBasicDTO(contactInGroup);
        }

        public void Add(ContactInGroup newContactInGroup)
        {
            _repo.Add(newContactInGroup);
        }

        public void Update(ContactInGroup newContactInGroup)
        {
            _repo.Update(newContactInGroup);
        }

        public void Delete(int contactInGroupId)
        {
            _repo.Delete(contactInGroupId);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
