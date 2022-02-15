﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Data
{
    public class Favorite
    {
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }
    }
}