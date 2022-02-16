using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Transaction
{
    public class TransactionEdit
    {
        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public string PaymentID { get; set; }

        public int ItemCount { get; set; }
    }
}