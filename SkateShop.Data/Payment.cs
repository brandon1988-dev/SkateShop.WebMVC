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
        CreditCard = 2,
        PayPal = 3
    }

    public class Payment
    {
        [Key]
        public string PaymentID { get; set; }

        [Required]
        public int TransactionID { get; set; }

        public PaymentMethod PaymentType { get; set; }

        public double PaymentAmount { get; set; }
    }
}