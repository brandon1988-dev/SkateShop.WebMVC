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
                CustomerID = model.CustomerID,
                ProductID = model.ProductID,
                ItemCount = model.ItemCount,
                DateOfTransaction = DateTime.Now
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
                                CustomerName = e.Customer.LastName,
                                ProductName = e.Product.ProductName,
                                CreatedUtc = DateTimeOffset.Now,
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
                        .SingleOrDefault(e => e.ID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new TransactionDetail
                    {
                        ID = entity.ID,
                        ItemCount = entity.ItemCount,
                        ProductID = entity.ProductID,
                        PaymentAmount = entity.PaymentAmount,
                        PaymentType = entity.Payment
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
                        .SingleOrDefault(e => e.ID == model.ID);
                if (entity is null)
                {
                    return false;
                }
                entity.ID = model.ID;
                entity.CustomerID = model.CustomerID;
                entity.ProductID = model.ProductID;
                entity.ItemCount = model.ItemCount;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

