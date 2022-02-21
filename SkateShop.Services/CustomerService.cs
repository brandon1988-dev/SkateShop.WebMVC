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
                Payment = model.PaymentType
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Select(
                        e =>
                            new CustomerListItem
                            {
                                CustomerID = e.CustomerID,
                                FirstName = e.FirstName,
                                LastName = e.LastName
                            }
                   );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Customers
                        .Single(e => e.CustomerID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new CustomerDetail
                    {
                        CustomerID = entity.CustomerID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
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
                        .Single(e => e.CustomerID == model.CustomerID && e.OwnerID == _userId);
                if (entity is null)
                {
                    return false;
                }
                entity.CustomerID = model.CustomerID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Payment = model.PaymentType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerID == customerID && e.OwnerID == _userId);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}