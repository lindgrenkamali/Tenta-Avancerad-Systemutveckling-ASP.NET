using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class ProductQuantityModel
    {
        [Key]
        [Display(Name = "ProduktQuantityID")]
        public int ProductQuantityID { get; set; }

        public int ProductID { get; set; }
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public int OrderID { get; set; }

        public OrderModel Order { get; set; }
    }

    //[Key]
    //[Display(Name = "ProduktQuantityID")]
    //public int ProductQuantityID { get; set; }

    ////public int ProductID { get; set; }
    //public ProductModel Product { get; set; }

    //public int Quantity { get; set; }

    //public int OrderId { get; set; }

    //public OrderModel Order { get; set; }
}
