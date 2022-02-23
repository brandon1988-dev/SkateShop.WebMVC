using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Transaction
{
    public class TransactionCreate
    {
        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Customer Last Name")]
        public string LastName { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        [Required]
        [ForeignKey(nameof(Payment))]
        public int PaymentID { get; set; }

        [Required]
        public double? PaymentAmount { get; set; }

        [Required]
        public int ItemCount { get; set; }

    }
}