using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Favorite
{
    public class FavoriteCreate
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
    }
}