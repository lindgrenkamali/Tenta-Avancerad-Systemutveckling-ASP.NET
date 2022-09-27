using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class CategoryModel
    {
        [Key]
        [Display(Name = "CategoryID")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }

    //[Key]
    //[Display(Name = "CategoryID")]
    //public int CategoryID { get; set; }
    //public string CategoryName { get; set; }

    //public int ProductId { get; set; }
    //public ProductModel Product { get; set; }
}
