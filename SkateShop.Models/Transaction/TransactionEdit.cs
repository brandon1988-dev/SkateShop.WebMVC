using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Transaction
{
    public class TransactionEdit
    {
        public int ID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Item #")]
        public int ItemCount { get; set; }
    }
}