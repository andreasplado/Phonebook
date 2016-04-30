using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.ObjectFactory
{
    public class FavoritesDTOFactory
    {
        public FavoritesDTOFactory()
        {
            
        }

        public FavoriteDTO CreateBasicDTO(Favorite favorite)
        {
            return new FavoriteDTO
            {
                FavoriteId = favorite.FavoriteId,
                UserId = favorite.UserId,
                Added = favorite.Added,
                Deleted = favorite.Deleted,
                Updated = favorite.Updated
            };
        }

    }
}
