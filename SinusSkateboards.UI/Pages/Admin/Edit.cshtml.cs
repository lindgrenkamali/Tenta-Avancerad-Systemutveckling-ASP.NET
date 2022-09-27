using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly SinusSkateboards.UI.Databas.SinusDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(SinusDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        [BindProperty]
        public ProductModel Product { get; set; }

        [BindProperty]
        public CategoryModel Category { get; set; }

        [BindProperty]
        public List<CategoryModel> Categories { get; set; }

        [BindProperty]
        public ColorModel Color { get; set; }

        [BindProperty]
        public List<ColorModel> Colors { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Categories = await _context.Category.ToListAsync();

            Colors = await _context.Color.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(x => x.Category).Include(x => x.Color).FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            Product.Category = await _context.Category.Where(x => x.CategoryID == Category.CategoryID).SingleAsync();

            Product.Color = await _context.Color.Where(x => x.ColorID == Color.ColorID).SingleAsync();

            if(Photo != null)
            {
                PhotoManager photoManager = new();

                Product.PhotoPath = photoManager.ChangePicture(Photo, _webHostEnvironment, Product);
            }
            

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(Product.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductModelExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
