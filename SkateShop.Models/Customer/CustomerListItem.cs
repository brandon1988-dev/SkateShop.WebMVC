using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models.Customer
{
    public class CustomerListItem
    {
        [Display(Name = "Customer #")]
        public int CustomerID { get; set; }

        [Display(Name = "Customer First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string LastName { get; set; }
    }
}