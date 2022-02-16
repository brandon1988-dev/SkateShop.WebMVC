using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class ProductListItem
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}