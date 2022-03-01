using SkateShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Models
{
    public class PaymentCreate
    {
        [Required]
        public int PaymentID { get; set; }

        [Required]
        public PaymentMethod PaymentType { get; set; } = PaymentMethod.Cash;

        public string CustomerName { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

        [Required]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [Display(Name = "Card #")]
        public int CardNumber { get; set; }

        
        [Display(Name = "Expiration Month")]
        public int ExpirationMonth { get; set; }

        [Display(Name = "Expiration Year")]
        public int ExpirationYear { get; set; }

        [Required]
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

    }
}