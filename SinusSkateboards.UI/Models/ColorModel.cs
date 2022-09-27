using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class ColorModel
    {
        [Key]
        [Display(Name = "ColorID")]
        public int ColorID { get; set; }

        public string ColorName { get; set; }


    }

    //[Key]
    //[Display(Name = "ColorID")]
    //public int ColorID { get; set; }

    //public string ColorName { get; set; }

    //public int ProductId { get; set; }
    //public ProductModel Product { get; set; }
}
