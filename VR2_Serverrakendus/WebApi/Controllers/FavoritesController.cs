using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Service;
using DAL;
using DAL.Interfaces;
using DAL.Repository;
using Domain;

namespace WebApi.Controllers
{
    public class FavoritesController : ApiController
    {
        private readonly FavoritesService _favoritesService;

        public FavoritesController()
        {
            _favoritesService = new FavoritesService();
        }

        // GET: api/Favorites
        public IHttpActionResult GetFavorites()
        {
            List<FavoriteDTO> favorites = _favoritesService.GetAll();
            if (favorites == null)
            {
                return NotFound();
            }

            return Ok(favorites);
        }

        // GET: api/Favorites/5
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult GetFavorite(int id)
        {
            FavoriteDTO favorite = _favoritesService.GetById(id);
            if (favorite == null)
            {
                return NotFound();
            }

            return Ok(favorite);
        }

        // PUT: api/Favorites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavorite(int id, Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorite.FavoriteId)
            {
                return BadRequest();
            }

            _favoritesService.Update(favorite);

            try
            {

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Favorites
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult PostFavorite(Favorite favorite)
        {
            bool isUserInFavorites = _favoritesService.IsUserInFavorites(favorite);

            //if user is not in favorites
            if (!isUserInFavorites)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _favoritesService.Add(favorite);

                return CreatedAtRoute("DefaultApi", new { id = favorite.FavoriteId }, favorite);

            }

            return CreatedAtRoute("DefaultApi", new { id = favorite.FavoriteId }, favorite);

        }

        // DELETE: api/Favorites/5
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult DeleteFavorite(int id)
        {
            FavoriteDTO favorite = _favoritesService.GetById(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _favoritesService.Delete(id);

            return Ok(favorite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _favoritesService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoriteExists(int id)
        {
            return _favoritesService.GetAll().Count(e => e.FavoriteId == id) > 0;
        }
    }
}