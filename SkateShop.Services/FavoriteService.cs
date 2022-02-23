using SkateShop.Data;
using SkateShop.Models.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Services
{
    public class FavoriteService
    {
        private readonly Guid _userId;
        public FavoriteService(Guid userId)
        {
            _userId = userId;
        }

        public bool FavoriteCreate(FavoriteCreate model)
        {
            var entity = new Favorite()
            {
                CustomerID =model.CustomerID,
                FavoriteID = model.FavoriteID,
                FavoriteName = model.FavoriteName,
                ProductID = model.ProductID,
                ProductName = model.ProductName,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FavoriteListItem> GetFavorites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Favorites
                    .Select(
                        e =>
                            new FavoriteListItem
                            {
                                FavoriteID = e.FavoriteID,
                                CustomerID = e.CustomerID
                            }
                   );
                return query.ToArray();
            }
        }
        public FavoriteDetail GetFavoriteByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Favorites
                        .SingleOrDefault(e => e.FavoriteID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new FavoriteDetail
                    {
                        FavoriteID = entity.FavoriteID,
                        ProductID = entity.ProductID,
                        ProductName = entity.ProductName
                    };
            }
        }

        public bool UpdateFavorite(FavoriteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .SingleOrDefault(e => e.FavoriteID == model.FavoriteID);
                if (entity is null)
                {
                    return false;
                }
                entity.ProductID = model.ProductID;
                entity.ProductName = model.ProductName;
                entity.FavoriteID = model.FavoriteID;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFavorite(int favoriteID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Favorites
                    .SingleOrDefault(e => e.FavoriteID == favoriteID);
                ctx.Favorites.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

