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
    public class ContactService
    {
        private readonly IContactRepository _repo;
        private readonly ContactDTOFactory _contactDtoFactory;

        public ContactService()
        {
            this._repo = new ContactRepository(new PhoneBookDbContext());
            this._contactDtoFactory = new ContactDTOFactory();
        }

        public List<ContactDTO> GetContactsByFirstName(string firstname)
        {
            return _repo.All.Where(x => x.ContactName == firstname).Select(x => _contactDtoFactory.CreateBasicDTO(x)).ToList();
        }



        public List<ContactDTO> GetContactsByLastName(string lastname)
        {
            return _repo.All.Where(x => x.ContactLastName == lastname).Select(x => _contactDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public List<ContactDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _contactDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public ContactDTO GetContactById(int contactId)
        {
            Contact contact = _repo.GetById(contactId);
            return _contactDtoFactory.CreateBasicDTO(contact);
        }

        public void Add(Contact newContact)
        {
            _repo.Add(newContact);
            _repo.SaveChanges();
            
        }

        public void Delete(int contactId)
        {
            _repo.Delete(contactId);
            _repo.SaveChanges();
        }

        public void Update(Contact newContact)
        {
            _repo.Update(newContact);
            _repo.SaveChanges();
        }
        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
