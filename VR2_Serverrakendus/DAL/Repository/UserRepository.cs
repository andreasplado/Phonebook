using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;
using Domain.Aggregate;

namespace DAL.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public List<UserWithContactCount> GetUsersWithContactCount()
        {
            return
                DbSet.Select(
                    p => new UserWithContactCount() { User = p, ContactCount = p.Contacts.Count }).ToList();
        }

    }
}
