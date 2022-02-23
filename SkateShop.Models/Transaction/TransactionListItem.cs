using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Transaction
{
    public class TransactionListItem
    {
        [Display(Name = "Transaction ID")]
        public int TransactionID { get; set; }

        [Display(Name = "Item Count")]
        public int ItemCount { get; set; }

        [Display(Name = "Customer Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name of Product")]
        public string ProductName { get; set; }

        [Display(Name = "Amount Paid")]
        public double? PaymentAmount { get; set; }

        [Display(Name = "Method of Payment")]
        public PaymentMethod PaymentType { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}