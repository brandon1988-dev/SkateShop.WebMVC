﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Favorite
{
    public class FavoriteListItem
    {
        [Display(Name = "Favorites #")]
        public int FavoriteID { get; set; }

        [Display(Name = "Customers #")]
        public int CustomerID { get; set; }


    }
}