using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Transaction
{
    public class TransactionDetail
    {
        [Display(Name = "Transaction #")]
        public int ID { get; set; }

        [Display(Name = "Item #")]
        public int ItemCount { get; set; }

        [Display(Name = "Product #")]
        public int ProductID { get; set; }

        [Display(Name = "Method of Payment")]
        public PaymentMethod PaymentType { get; set; }

        [Display(Name = "Amount Paid")]
        public double? PaymentAmount { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}