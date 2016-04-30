using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL;
using DAL.Interface;
using DAL.Repositories;
using DAL.Repository;
using Domain;

namespace BLL.Service
{
    public class FavoritesService
    {
        private readonly IFavoriteRepository _repo;
        private readonly FavoritesDTOFactory _favoritesDtoFactory;

        public FavoritesService()
        {
            _repo = new FavoritesRepository(new PhoneBookDbContext());
            _favoritesDtoFactory = new FavoritesDTOFactory();
        }

        public bool IsUserInFavorites(Favorite newFavorite)
        {
            List<Favorite> favorites = _repo.GetFavoriteByUserId(newFavorite.UserId);
            if (favorites.Count == 0)
            {
                //user is not in favorites yet
                return false;
            }
            else
            {
                //user is in favorites!
                return true;
            }
        }

        public List<FavoriteDTO> GetAll()
        {
            return _repo.All.ToList().Select(x => _favoritesDtoFactory.CreateBasicDTO(x)).ToList();
        }

        public FavoriteDTO GetById(int favoriteId)
        {
            Favorite favorite = _repo.GetById(favoriteId);
            return _favoritesDtoFactory.CreateBasicDTO(favorite);
        }
        public void Add(Favorite newFavorite)
        {
            _repo.Add(newFavorite);
            _repo.SaveChanges();
        }

        public void Delete(int favoriteId)
        {
            _repo.Delete(favoriteId);
            _repo.SaveChanges();
        }

        public void Update(Favorite newFavorite)
        {
            _repo.Update(newFavorite);
            _repo.SaveChanges();
        }
        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
