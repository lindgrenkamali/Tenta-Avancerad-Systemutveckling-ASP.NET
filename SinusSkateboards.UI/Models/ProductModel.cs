using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Models
{
    public class ProductModel
    {
        [Key]
        [Display(Name = "ProductID")]
        public int ProductID { get; set; }

        [Required]
        public string Title { get; set; }

        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }

        public int ColorID { get; set; }
        public ColorModel Color { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(19,2)")]
        public decimal Price { get; set; }

        public string PhotoPath { get; set; }

    }

    //[Key]
    //[Display(Name = "ProductID")]
    //public int ProductID { get; set; }


    //public string Title { get; set; }

    //public CategoryModel Category { get; set; }

    //public ColorModel Color { get; set; }


    //public string Description { get; set; }

    //[Column(TypeName = "decimal(19,4)")]
    //public decimal Price { get; set; }


    //public string PhotoPath { get; set; }
}
