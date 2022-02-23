using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Data
{
    public class Favorite
    {
        [Key]
        public int FavoriteID { get; set; }

        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string FavoriteName { get; set; }
        public string ProductName { get; set; }
    }
}