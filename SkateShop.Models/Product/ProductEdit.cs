﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class ProductEdit
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number of Product")]
        public int AvailableStock { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "It is a complete")]
        public bool IsComplete { get; set; }
    }
}