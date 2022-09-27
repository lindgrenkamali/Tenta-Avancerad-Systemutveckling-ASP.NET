using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Pages
{
    public class IndexModel : PageModel
    {

        private readonly SinusDbContext _context;

        public IndexModel(SinusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<ProductModel> Products { get; set; }

        [BindProperty]
        public List<CategoryModel> Categories { get; set; }

        [BindProperty]
        public List<ColorModel> Colors { get; set; }


        [BindProperty]
        public string Search { get; set; }

        public async Task OnGet(string search, int? category, int? color, int? otherProducts)
        {

            Categories = await _context.Category.ToListAsync();
            Colors = await _context.Color.ToListAsync();

            if (!String.IsNullOrEmpty(search))
            {
                Products = await _context.Product.Include(x => x.Category).Include(x => x.Color).Where(x => x.Title.Contains(search)).ToListAsync();
            }

            else if(otherProducts != null)
            {
                Products = await _context.Product.Include(x => x.Category).Include(x => x.Color).Where(x => x.ProductID != otherProducts && x.Category.CategoryID == category).ToListAsync();
            }

            else if (category != null)
            {
                Products = await _context.Product.Include(x => x.Category).Include(x => x.Color).Where(x => x.Category.CategoryID == category).ToListAsync();

            }
            else if(color != null)
            {
                Products = await _context.Product.Include(x => x.Category).Include(x => x.Color).Where(x => x.Color.ColorID == color).ToListAsync();

            }

            else
            {

                Products = await _context.Product.Include(x => x.Category).Include(x => x.Color).ToListAsync();

            }
            
        }

        public IActionResult OnPost()
        {
            
            return RedirectToPage("/Index", new {search = Search });
        }
    }
}
