using SkateShop.Data;
using SkateShop.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool TransactionCreate(TransactionCreate model)
        {
            var entity = new Transaction()
            {
                TransactionID = model.CustomerID,
                ProductID = model.ProductID,
                PaymentID = model.PaymentID,
                ItemCount = model.ItemCount,
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Select(
                        e =>
                            new TransactionListItem
                            {
                                ID = e.ID,
                                ItemCount = e.ItemCount,
                                LastName = e.LastName,
                                ProductName = e.ProductName,
                                CreatedUtc = DateTimeOffset.Now,
                                PaymentAmount = e.PaymentAmount
                            }
                   );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Transactions
                        .SingleOrDefault(e => e.TransactionID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new TransactionDetail
                    {
                        TransactionID = entity.TransactionID,
                        ItemCount = entity.ItemCount,
                        LastName = entity.LastName,
                        ProductName = entity.ProductName,
                        PaymentAmount = entity.PaymentAmount,
                        PaymentType = entity.PaymentType
                    };
            }
        }
        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .SingleOrDefault(e => e.TransactionID == model.TransactionID);
                if (entity is null)
                {
                    return false;
                }
                entity.TransactionID = model.TransactionID;
                entity.CustomerID = model.CustomerID;
                entity.LastName = model.LastName;
                entity.PaymentID = model.PaymentID;
                entity.ProductID = model.ProductID;
                entity.ItemCount = model.ItemCount;

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
                    .SingleOrDefault(e => e.CustomerID == customerID);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

