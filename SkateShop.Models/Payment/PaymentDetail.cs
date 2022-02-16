using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Payment
{
    public class PaymentDetail
    {
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [Display(Name = "Payment ID")]
        public string PaymentID { get; set; }

        [Display(Name = "Method of Payment")]
        public PaymentMethod PaymentType { get; set; }
    }
}