using SkateShop.Data;
using SkateShop.Models;
using SkateShop.Models.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Services
{
    public class ProductService
    {
        private readonly Guid _userId;
        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool ProductCreate(ProductCreate model)
        {
            var entity = new Product()
            {
                OwnerID = _userId,
                ProductName = model.ProductName,
                AvailableStock = model.AvailableStock,
                Price = model.Price,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Select(
                        e =>
                            new ProductListItem
                            {
                                ProductID = e.ProductID,
                                ProductName = e.ProductName,
                                AvailableStock = e.AvailableStock,
                                Price = e.Price,
                            }
                   );
                return query.ToArray();
            }
        }
        public ProductDetail GetProductByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Products
                        .SingleOrDefault(e => e.ProductID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new ProductDetail
                    {
                        ProductID = entity.ProductID,
                        ProductName = entity.ProductName,
                        AvailableStock = entity.AvailableStock,
                        Price = entity.Price,
                        CreatedUtc = DateTime.UtcNow,
                    };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductID == model.ProductID);
                if (entity is null)
                {
                    return false;
                }
                entity.ProductID = model.ProductID;
                entity.ProductName = model.ProductName;
                entity.AvailableStock = model.AvailableStock;
                entity.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .SingleOrDefault(e => e.ProductID == productID);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

