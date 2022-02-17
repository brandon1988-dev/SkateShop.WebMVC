using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Customer
{
    public class CustomerDetail
    {
        [Display(Name = "Favorite ID")]
        public int FavoriteID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Customer Name")]
        public string FullName { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentType { get; set; }
    }
}