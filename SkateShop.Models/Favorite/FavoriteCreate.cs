using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Favorite
{
    public class FavoriteCreate
    {

        public int CustomerID { get; set; }
        [Required]
        public int FavoriteID { get; set; }
        public string FavoriteName { get; set; }
        
        public int ProductID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
    }
}