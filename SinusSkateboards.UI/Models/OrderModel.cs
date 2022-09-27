using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class OrderModel
    {
        [Key]
        [Display(Name = "OrderID")]
        public int OrderID { get; set; }
        public UserModel User { get; set; }

        public DateTime OrderDate { get; set; }
        
        public List<ProductQuantityModel> Products {get; set;}
    }
}
