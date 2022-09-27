using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class UserModel
    {
        [Key]
        [Display(Name = "UserID")]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PhoneNumber { get; set; }

        public int OrderId { get; set; }

        public OrderModel Order { get; set; }
    }
}
