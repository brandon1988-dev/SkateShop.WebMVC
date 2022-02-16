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
        [Display(Name = "Customer ID")]
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        public string Name { get; set; }
    }
}