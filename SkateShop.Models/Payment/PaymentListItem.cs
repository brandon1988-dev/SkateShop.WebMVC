using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class PaymentListItem
    {
        [ForeignKey(nameof(Customer))]
        [Display(Name = "Customer #")]
        public int CustomerID { get; set; }

        [Display(Name = "Payment #")]
        public int PaymentID { get; set; }
    }
}