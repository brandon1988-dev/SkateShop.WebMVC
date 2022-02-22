using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Favorite
{
    public class FavoriteCreate
    {
        public string ProductName { get; set; }

        public virtual Product Product { get; set; }

    }
}