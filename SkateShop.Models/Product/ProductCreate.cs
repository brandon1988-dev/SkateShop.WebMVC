using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class ProductCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Available Stock")]
        public int AvailableStock { get; set; }

        [Required]
        public decimal Price { get; set; }

        /*[Required] // (Stretch Goal)
          [Display(Name = "It is a complete")]
          public bool IsComplete { get; set; }*/
    }
}