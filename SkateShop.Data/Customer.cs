using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Data
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public virtual PaymentMethod Payment { get; set; }
        public virtual Favorite Favorite { get; set; }
    }
}