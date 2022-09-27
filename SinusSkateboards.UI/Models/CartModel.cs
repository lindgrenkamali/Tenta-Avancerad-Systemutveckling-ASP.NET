using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class CartModel
    {
        
        public List<ProductQuantityModel> ProductQuantity { get; set; }

        [Column(TypeName = "decimal(19,2)")]
        public decimal Price { get; set; }
    }
}
