using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.UI.Databas;
using SinusSkateboards.UI.Models;

namespace SinusSkateboards.UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly SinusDbContext _context;
        private readonly SignInManager<AdminModel> _signInManager;

        public IndexModel(SinusDbContext context, SignInManager<AdminModel> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public IList<ProductModel> ProductModel { get;set; }

        public async Task OnGetAsync()
        {
            ProductModel = await _context.Product.Include(x => x.Category).Include(x => x.Color).ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
