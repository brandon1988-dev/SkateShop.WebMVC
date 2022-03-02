using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Data
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        [ForeignKey(nameof(Payment))]
        public int PaymentID { get; set; }

        [Required]
        public double? PaymentAmount { get; set; }

        [Required]
        public DateTime? DateOfTransaction { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }

        public virtual Payment Payment { get; set; }
    }
}