using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service.Interfaces;

namespace VR2_Klientrakendus.Service
{
    public class FavoritesService : BaseService, IFavoritesService
    {

        public FavoritesService() : base(ServiceConstants.FavoriteServiceUrl)
        {
        }
        public async Task<ObservableCollection<Favorite>> GetAll()
        {
            return await base.GetData<ObservableCollection<Favorite>>(ServiceConstants.FavoriteServiceUrl);
        }

        public async Task<Favorite> GetById(int favoriteId)
        {
            return await base.GetData<Favorite>(ServiceConstants.FavoriteServiceUrl + "/" + favoriteId);
        }

        public async Task<Favorite> Add(Favorite favorite)
        {
            return await base.PostData(favorite);
        }

        public async Task<Favorite> Update(Favorite favorite, int favoriteId)
        {
            return await base.PutData(favorite, favoriteId);
        }

        public async Task<Favorite> Delete(int favoriteId)
        {
            return await base.DeleteData<Favorite>(favoriteId);
        }
    }
}
