using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class ProductDetail
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Available Items In Stock")]
        public int AvailableStock { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}