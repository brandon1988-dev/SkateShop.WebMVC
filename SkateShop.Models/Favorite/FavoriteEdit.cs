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
        [Display(Name = "Favorite #")]
        public int FavoriteID { get; set; }

        [Display(Name = "Favorite Product #")]
        public int ProductID { get; set; }
    }
}