using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly SinusSkateboards.UI.Databas.SinusDbContext _context;

        public DetailsModel(SinusSkateboards.UI.Databas.SinusDbContext context)
        {
            _context = context;
        }

        public ProductModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.Product.Include(x => x.Category).Include(x => x.Color).FirstOrDefaultAsync(m => m.ProductID == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
