﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Transaction
{
    public class TransactionListItem
    {
        public int ID { get; set; }

        public int ItemCount { get; set; }

        public string CustomerName { get; set; }

        public string ProductName { get; set; }
    }
}