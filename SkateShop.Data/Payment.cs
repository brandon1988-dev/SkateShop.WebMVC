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
        Cash,
        CreditCard,
        PayPal
    }

    public class Payment
    {
        [Key]
        public string PaymentID { get; set; }

        [Required]
        [ForeignKey(nameof(Transaction))]
        public int TransactionID { get; set; }

        public PaymentMethod PaymentType { get; set; }
    }
}