using SkateShop.Data;
using SkateShop.Models;
using SkateShop.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Services
{
    public class PaymentService
    {
        private readonly Guid _userId;
        public PaymentService(Guid userId)
        {
            _userId = userId;
        }

        public bool PaymentCreate(PaymentCreate model)
        {
            var entity = new Payment()
            {
                PaymentID = model.PaymentID,
                PaymentType = model.PaymentType

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Payments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PaymentListItem> GetPayment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Payments
                    .Select(
                        e =>
                            new PaymentListItem
                            {
                                PaymentID = e.PaymentID
                            }
                   );
                return query.ToArray();
            }
        }

        public PaymentDetail GetPaymentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Payments
                        .SingleOrDefault(e => e.PaymentID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new PaymentDetail
                    {
                        PaymentID = entity.PaymentID,
                        PaymentType = entity.PaymentType,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }
        public bool UpdatePayment(PaymentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =  
                    ctx
                        .Payments
                        .SingleOrDefault(e => e.PaymentID == model.PaymentID);
                if (entity is CreditCard creditCard)
                {
                    creditCard.PaymentID = model.PaymentID;
                    creditCard.BillingAddress = model.BillingAddress;
                    creditCard.CardHolderName = model.CardHolderName;
                    creditCard.CardNumber = model.CardNumber;
                    creditCard.ExpirationMonth = model.ExpirationMonth;
                    creditCard.ExpirationYear = model.ExpirationYear;
                }
                else if (entity is Paypal paypal)
                {
                    paypal.UserEmail = model.UserEmail;
                }
                    return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePayment(int paymentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Payments
                    .SingleOrDefault(e => e.PaymentID == paymentID);
                ctx.Payments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

