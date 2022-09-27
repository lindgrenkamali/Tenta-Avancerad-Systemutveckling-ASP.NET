using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CreateModel : PageModel
    {
        private readonly SinusDbContext _context;

        public IWebHostEnvironment _webHostEnvironment { get; }

        public CreateModel(SinusDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            Categories = await _context.Category.ToListAsync();
            Colors = await _context.Color.ToListAsync();

            return Page();
        }

        [BindProperty]
        [Required]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public ProductModel Product { get; set; }


        [BindProperty]
        public List<CategoryModel> Categories { get; set; }

        [BindProperty]
        public List<ColorModel> Colors { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            PhotoManager photoManager = new();

            Product.Category =  await _context.Category.Where(x => x.CategoryID == Product.CategoryID).SingleAsync();

            Product.Color = await _context.Color.Where(x => x.ColorID == Product.ColorID).SingleAsync();

            Product.PhotoPath = photoManager.AddPicture(Photo, _webHostEnvironment);


            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Product.AddAsync(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
