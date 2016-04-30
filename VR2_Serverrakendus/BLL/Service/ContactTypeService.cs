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
    public class ContactTypeService
    {
        private readonly IContactTypeRepository _repo;
        private readonly ContactTypeDTOFactory _contactTypeDtoFactory;

        public ContactTypeService()
        {
            this._repo = new ContactTypeRepository(new PhoneBookDbContext());
            this._contactTypeDtoFactory = new ContactTypeDTOFactory();
        }

        public List<ContactTypeDTO> GetContactTypeNameByValue(string contactValue)
        {
            return
                _repo.All.Where(x => x.ContactTypeValue == contactValue)
                    .ToList()
                    .Select(x => _contactTypeDtoFactory.CreateBasicDTO(x))
                    .ToList();
        }

        public List<ContactTypeDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _contactTypeDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public ContactTypeDTO GetById(int contactTypeId)
        {
            ContactType contactType = _repo.GetById(contactTypeId);
            return _contactTypeDtoFactory.CreateBasicDTO(contactType);
        }
        public void Add(ContactType newContactType)
        {
            _repo.Add(newContactType);
            _repo.SaveChanges();
        }

        public void Delete(int contactTypeId)
        {
            _repo.Delete(contactTypeId);
            _repo.SaveChanges();
        }

        public void Update(ContactType newContactType)
        {
            _repo.Update(newContactType);
            _repo.SaveChanges();
        }
        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
