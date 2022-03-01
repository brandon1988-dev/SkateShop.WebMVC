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
            using (var ctx = new ApplicationDbContext())
            {
                var pay = new Payment();
                if (model.PaymentType == PaymentMethod.Visa ||
                    model.PaymentType == PaymentMethod.Discover ||
                    model.PaymentType == PaymentMethod.Mastercard ||
                    model.PaymentType == PaymentMethod.AmericanExpress)
                {
                    CreditCard creditCard = new CreditCard();
                    creditCard.PaymentID = model.PaymentID;
                    creditCard.BillingAddress = model.BillingAddress;
                    creditCard.CardHolderName = model.CardHolderName;
                    creditCard.CardNumber = model.CardNumber;
                    creditCard.ExpirationMonth = model.ExpirationMonth;
                    creditCard.ExpirationYear = model.ExpirationYear;
                    creditCard.PaymentType = model.PaymentType;
                }
                else if (model.PaymentType == PaymentMethod.PayPal)
                {
                    Paypal paypal = new Paypal();
                    paypal.UserEmail = model.UserEmail;
                }
                ctx.Payments.Add(pay);
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
                                PaymentID = e.PaymentID,
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
                else if (entity.PaymentType == PaymentMethod.Visa || 
                         entity.PaymentType == PaymentMethod.AmericanExpress ||
                         entity.PaymentType == PaymentMethod.Discover ||
                         entity.PaymentType == PaymentMethod.Mastercard)
                {
                    CreditCard creditCard = (CreditCard)entity;
                    return
                        new PaymentDetail
                        {
                            PaymentID = entity.PaymentID,
                            PaymentType = entity.PaymentType,
                            CreatedUtc = DateTime.Now,
                            BillingAddress = entity.BillingAddress,
                            CardHolderName = creditCard.CardHolderName,
                            CardNumber = creditCard.CardNumber,
                        };
                }

                else if (entity.PaymentType == PaymentMethod.PayPal)
                {
                    Paypal paypal = (Paypal)entity;
                    return
                        new PaymentDetail
                        {
                            PaymentID = entity.PaymentID,
                            UserEmail = paypal.UserEmail,
                            PaymentType = entity.PaymentType,
                            BillingAddress = entity.BillingAddress,
                            CreatedUtc = DateTimeOffset.UtcNow
                        };
                }
                    return
                        new PaymentDetail
                        {
                            PaymentID = entity.PaymentID,
                            PaymentType = entity.PaymentType,
                            BillingAddress = entity.BillingAddress,
                            CreatedUtc = DateTimeOffset.UtcNow
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
                if (entity == null)
                {
                    return false;
                }
                else if (entity is CreditCard creditCard)
                {
                    creditCard.PaymentID = model.PaymentID;
                    creditCard.BillingAddress = model.BillingAddress;
                    creditCard.CardHolderName = model.CardHolderName;
                    creditCard.CardNumber = model.CardNumber;
                    creditCard.ExpirationMonth = model.ExpirationMonth;
                    creditCard.ExpirationYear = model.ExpirationYear;
                    creditCard.PaymentType = model.PaymentType;
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

