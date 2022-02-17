using SkateShop.Data;
using SkateShop.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                OwnerID = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.SingleOrDefault(C => C.CustomerID == entity.CustomerID);
                if (customer is null)
                {
                    return false;
                }
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                       .Customers
                       .Select(e => new CustomerListItem
                       {
                           CustomerID = e.CustomerID,
                           FullName = e.FullName
                       }
                      );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerDetail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Customers
                        .SingleOrDefault(e => e.CustomerID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new CustomerDetail
                    {
                        FavoriteID = entity.Favorite.FavoriteID,
                        CustomerID = entity.CustomerID,
                        FullName = entity.FullName,
                        PaymentType = entity.Payment
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .SingleOrDefault(e => e.CustomerID == model.CustomerID);
                if (entity is null)
                {
                    return false;
                }
                entity.CustomerID = model.CustomerID;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumID == albumID);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}