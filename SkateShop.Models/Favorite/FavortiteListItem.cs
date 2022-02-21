using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Favorite
{
    public class FavortiteListItem
    {
        [Display(Name = "Favorite ID")]
        public int FavoriteID { get; set; }

        [Display(Name = "Favorite Name")]
        public string FavoriteName { get; set; }
    }
}