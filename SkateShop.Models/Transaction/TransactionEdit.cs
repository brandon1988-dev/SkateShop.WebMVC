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
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Customer Last Name")]
        public string LastName { get; set; }

        public int ProductID { get; set; }

        public int PaymentID { get; set; }

        public int ItemCount { get; set; }
    }
}