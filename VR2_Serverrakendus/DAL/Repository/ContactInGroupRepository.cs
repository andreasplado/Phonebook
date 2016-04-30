using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ContactInGroupRepository : EFRepository<ContactInGroup>, IContactInGroupRepository
    {
        public ContactInGroupRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
