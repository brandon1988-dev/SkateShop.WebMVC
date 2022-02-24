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

        [Required]
        [Display(Name = "Customer #")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Favorite #")]
        public int FavoriteID { get; set; }

        [Display(Name = "Favorites Name")]
        public string FavoriteName { get; set; }

        [Required]
        [Display(Name = "Product #")]
        public int ProductID { get; set; }
    }
}