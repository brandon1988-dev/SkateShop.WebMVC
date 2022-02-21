using SkateShop.Data;
using SkateShop.Models.Favorite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Customer
{
    public class CustomerDetail
    {
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Customer First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentType { get; set; }

        [Display(Name = "Favorites")]
        public List<FavortiteListItem> Favorites { get; set; }

        public int FavoriteID { get; set; }
    }
}