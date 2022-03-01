using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Data
{
    public enum PaymentMethod
    {
        Cash = 1,
        Visa = 2, Mastercard = 3, Discover = 4, AmericanExpress = 5,
        PayPal = 6
    }

    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public PaymentMethod PaymentType { get; set; }

        [Required]
        public string BillingAddress { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public virtual Customer Customer { get; set; }


    }

    public class CreditCard : Payment
    {
        [Required]
        public string CardHolderName { get; set; }

        [Required]
        public int CardNumber { get; set; }

        [Required]
        public int ExpirationMonth { get; set; }

        [Required]
        public int ExpirationYear { get; set; }
    }

    public class Paypal : Payment
    {
        [Required]
        public string UserEmail { get; set; }
    }
}