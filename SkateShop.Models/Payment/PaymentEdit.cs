using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Payment
{
    public class PaymentEdit
    {
        public int PaymentID { get; set; }

        [Display(Name= "Billing Address")]
        public string BillingAddress { get; set; }

        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }
        
        [Display(Name = "Card Number")]
        public int CardNumber { get; set; }

        [Display(Name = "Card Expiration Month")]
        public int ExpirationMonth { get; set; }

        [Display(Name = "Card Expiration Year")]
        public int ExpirationYear { get; set; }

        [Display(Name ="User Email")]
        public string UserEmail { get; set; }

        public PaymentMethod PaymentType { get; set; }

    }
}
