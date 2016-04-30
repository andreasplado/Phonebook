using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace DAL.Repository
{
    public class FavoritesRepository : EFRepository<Favorite>, IFavoriteRepository
    {
        public FavoritesRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Favorite> GetFavoriteByUserId(int userId)
        {
            return All.FindAll(x => x.UserId == userId).ToList();
        }
    }
}
