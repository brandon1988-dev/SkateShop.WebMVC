using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Data
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        public int AvailableStock { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}