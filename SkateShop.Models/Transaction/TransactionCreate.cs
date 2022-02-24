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

        public int CustomerID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int ItemCount { get; set; }
    }
}