using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Payment
{
    public class PaymentCreate
    {
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public PaymentMethod PaymentType { get; set; }
    }
}