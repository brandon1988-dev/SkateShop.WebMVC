﻿using System;
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
        public string PaymentID { get; set; }

        public PaymentMethod PaymentType { get; set; }

        public string BillingAddress { get; set; }
    }

    public class CreditCard : Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }
}