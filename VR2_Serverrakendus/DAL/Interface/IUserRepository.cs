using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Aggregate;

namespace DAL.Interfaces
{
    public interface IUserRepository : IEFRepository<User>
    {
        List<UserWithContactCount> GetUsersWithContactCount();

    }
}
