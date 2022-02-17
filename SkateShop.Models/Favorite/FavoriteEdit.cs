using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Favorite
{
    public class FavoriteEdit
    {
        [Display(Name = "Favorite ID")]
        public int FavoriteID { get; set; }

        [Display(Name = "Favorite Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Favorite Product Name")]
        public string ProductName { get; set; }
    }
}